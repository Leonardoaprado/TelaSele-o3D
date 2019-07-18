using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionarPersonagem : MonoBehaviour
{
    public Transform EsquerdaFora;
    public Transform Esquerda;
    public Transform Centro;
    public Transform Direita;
    public Transform DireitaFora;
    public Transform[] ListaDePersonagens;
    public GameObject[] Personagens;
    private int PersonagemAtual = 0;

    void Start()
    {
        Personagens = new GameObject[ListaDePersonagens.Length];
        int indice = 0;
        foreach(Transform t in ListaDePersonagens)
        {
            Personagens[indice++] = GameObject.Instantiate(t.gameObject, DireitaFora.position, Quaternion.identity) as GameObject;
        }

    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(10,(Screen.height - 50)/2 , 100 , 50), "Anterior"))
        {
            PersonagemAtual--;
            if(PersonagemAtual < 0)
            {
                PersonagemAtual = 0;
            }
        }
        if (GUI.Button(new Rect(Screen.width - 100 -10,(Screen.height -50) / 2, 100, 50), "Próximo"))
        {
            PersonagemAtual++;
            if(PersonagemAtual >= Personagens.Length)
            {
                PersonagemAtual = Personagens.Length - 1;
            }
        }

        GameObject personagemSelecionado = Personagens[PersonagemAtual];
        string nomePersonagem = personagemSelecionado.name;

        GUI.Label(new Rect((Screen.width - 100) / 2, 20, 200, 50), nomePersonagem);

        int indicePersonagemMeio = PersonagemAtual;
        int indicePersonagemEsquerda = PersonagemAtual - 1;
        int indicePersonagemDireita = PersonagemAtual + 1;

        for(int indice = 0; indice < Personagens.Length ; indice++)
        {
            Transform transf = Personagens[indice].transform;
            if(indice < indicePersonagemEsquerda)
            {
                transf.position = Vector3.Lerp(transf.position, Esquerda.position, Time.deltaTime);
            }
            else if(indice > indicePersonagemDireita)
            {
                transf.position = Vector3.Lerp(transf.position, Direita.position, Time.deltaTime);
            }
            else if(indice == indicePersonagemEsquerda)
            {
                transf.position = Vector3.Lerp(transf.position, Esquerda.position, Time.deltaTime);
            }
            else if(indice == indicePersonagemDireita)
            {
                transf.position = Vector3.Lerp(transf.position, Direita.position, Time.deltaTime);
            }
            else if(indice == indicePersonagemMeio)
            {
                transf.position = Vector3.Lerp(transf.position, Centro.position, Time.deltaTime);
            }
        }

    }




}
