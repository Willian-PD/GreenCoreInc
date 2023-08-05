using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private int level;
    [SerializeField]
    private string name;
    private string description;
    private bool status;

    // Start is called before the first frame update
    void Start()
    {
        this.level = 0;
        this.status = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumLevel()
    {
        bool levelUpRio = true;
        bool levelUpReflorestamento = true;
        bool levelUpReciclagem = true;
        bool levelUpEnSolar = true;
        bool levelUpEnEolica = true;

        if (this.tag == "Reflorestammento" && this.level == 0)
        {
            this.level += 1;
            levelUpReflorestamento = false;
            //rodar a animação!
        }
        if (this.tag == "Reciclagem_Lixo" && this.level == 0)
        {
            this.level += 1;
            levelUpReciclagem = false;
            //rodar a animação!
        }
        if (this.tag == "Despoluir_Rio" && this.level == 0)
        {
            this.level += 1;
            levelUpRio = false;
            //rodar a animação!
        }
        if (this.tag == "Energia_Solar" && this.level == 0)
        {
            this.level += 1;
            levelUpEnSolar = false;
            //rodar a animação!
        }
        if (this.tag == "Energia_Eolica" && this.level == 0)
        {
            this.level += 1;
            levelUpEnEolica = false;
            //rodar a animação!
        }

        //upgrade do rio
        if (GameObject.FindGameObjectsWithTag("Despoluir_Rio")[0].GetComponent<Button>().interactable == false && levelUpRio)
        {
            Resource rio = GameObject.FindGameObjectsWithTag("Despoluir_Rio")[0].GetComponent<Resource>();
            if (rio.level < 3 && rio.status == true)
            {
                if (rio.level < 2)
                {

                    if (GameObject.FindGameObjectsWithTag("Reciclagem_Lixo")[0].GetComponent<Resource>().level == 1)
                    {
                        rio.level += 1;
                        // animacao nivel 2
                    }
                    else
                    {
                        rio.status = false;
                        //animacao de rio poluido
                    }
                }
                else
                {
                    rio.level += 1;
                    // animacao nivel 3
                }
            }
        }

        //upgrade da reciclagem
        if (GameObject.FindGameObjectsWithTag("Reciclagem_Lixo")[0].GetComponent<Button>().interactable == false && levelUpReciclagem)
        {
            Resource reciclagem = GameObject.FindGameObjectsWithTag("Reciclagem_Lixo")[0].GetComponent<Resource>();
            if (reciclagem.level < 3)
            {
                if (reciclagem.level < 2)
                {
                    if (GameObject.FindGameObjectsWithTag("Despoluir_Rio")[0].GetComponent<Button>().interactable == false)
                    {
                        reciclagem.level += 1;
                        // animacao nivel 2
                    }
                }
                else
                {
                    reciclagem.level += 1;
                    // animacao nivel 3
                }
            }
        }

        //upgrade da En. Solar
        if (GameObject.FindGameObjectsWithTag("Energia_Solar")[0].GetComponent<Button>().interactable == false && levelUpEnSolar)
        {
            Resource enSolar = GameObject.FindGameObjectsWithTag("Energia_Solar")[0].GetComponent<Resource>();
            if (enSolar.level < 3)
            {
                if (enSolar.level < 2)
                {
                    enSolar.level += 1;
                    //animacao nivel 2
                }
                else
                {
                    enSolar.level += 1;
                    //animacao nivel 3
                }
            }
        }

        //upgrade do reflorestamento
        if (GameObject.FindGameObjectsWithTag("Reflorestammento")[0].GetComponent<Button>().interactable == false && levelUpReflorestamento)
        {
            Resource reflorestamento = GameObject.FindGameObjectsWithTag("Reflorestammento")[0].GetComponent<Resource>();
            if (reflorestamento.level < 3)
            {
                Resource rio = GameObject.FindGameObjectsWithTag("Despoluir_Rio")[0].GetComponent<Resource>();
                Resource reciclagem = GameObject.FindGameObjectsWithTag("Reciclagem_Lixo")[0].GetComponent<Resource>();
                Resource enSolar = GameObject.FindGameObjectsWithTag("Energia_Solar")[0].GetComponent<Resource>();
                if (rio.level == 3 && reciclagem.level == 3 && enSolar.level == 3)
                {

                    reflorestamento.level += 1;
                }

                if (reflorestamento.level < 2)
                {
                    reflorestamento.level += 1;
                    //animacao nivel 2
                }
                else
                {
                    reflorestamento.level += 1;
                    //animacao nivel 3
                }
            }
        }

        //upgrade da En. Eolica
        if (GameObject.FindGameObjectsWithTag("Energia_Eolica")[0].GetComponent<Button>().interactable == false && (levelUpEnEolica || (GameObject.FindGameObjectsWithTag("Despoluir_Rio")[0].GetComponent<Resource>().level == 3 && GameObject.FindGameObjectsWithTag("Reciclagem_Lixo")[0].GetComponent<Resource>().level == 3 && GameObject.FindGameObjectsWithTag("Energia_Solar")[0].GetComponent<Resource>().level == 3)))
        {

            Resource enEolica = GameObject.FindGameObjectsWithTag("Energia_Eolica")[0].GetComponent<Resource>();
            if (enEolica.level < 3 && enEolica.status == true)
            {
                Resource rio = GameObject.FindGameObjectsWithTag("Despoluir_Rio")[0].GetComponent<Resource>();
                Resource reciclagem = GameObject.FindGameObjectsWithTag("Reciclagem_Lixo")[0].GetComponent<Resource>();
                Resource enSolar = GameObject.FindGameObjectsWithTag("Energia_Solar")[0].GetComponent<Resource>();
                if (rio.level == 3 && reciclagem.level == 3 && enSolar.level == 3)
                {
                    enEolica.level += 2;
                }

                else if (enEolica.level < 2)
                {
                    if (reciclagem.level == 1)
                    {
                        enEolica.level += 1;
                        //animacao nivel 2
                    }
                    else
                    {
                        enEolica.status = false;
                        //animacao de usinas
                    }
                }
                else
                {
                    enEolica.level += 1;
                    //animacao nivel 3
                }

            }
        }

        print("--------------------------");
        print("RIO " + GameObject.FindGameObjectsWithTag("Despoluir_Rio")[0].GetComponent<Resource>().level);
        print("REFLORESTAMENTO " + GameObject.FindGameObjectsWithTag("Reflorestammento")[0].GetComponent<Resource>().level);
        print("RECICLAGEM " + GameObject.FindGameObjectsWithTag("Reciclagem_Lixo")[0].GetComponent<Resource>().level);
        print("EN SOLAR " + GameObject.FindGameObjectsWithTag("Energia_Solar")[0].GetComponent<Resource>().level);
        print("EN EOLICA " + GameObject.FindGameObjectsWithTag("Energia_Eolica")[0].GetComponent<Resource>().level);
    }
}
