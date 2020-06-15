using AhorcadoGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhorcadoGame
{
    public partial class Form1 : Form
    {
        private bool isLoad { get; set; } = true;
        private List<Animal> animals = new List<Animal>();
        private List<Frutas> frutas = new List<Frutas>();
        private List<Carro> carros = new List<Carro>();
        private string word = "";
        private int num = 0;
        private int contador = 0;
        private int intentos = 1;
        private int gana = 0;
        char[] lines;
        bool play = true;

        public Form1()
        {
            InitializeComponent();
            lines = new char[word.Length];

        }
        #region Logica del juego


        public void juego(char letter = 'Ñ')
        {

            if (cboCategorias.SelectedIndex != 0)
            {

                char[] wordArry = word.ToCharArray();

                for (int i = 0; i < wordArry.Length; i++)
                {
                    if (wordArry[i] == letter)
                    {
                        lines[i] = letter;

                        lvLista.Items[i].Text = lines[i].ToString();
                        gana++;
                        contador++;

                    }

                }
                if (contador == 0)
                {
                    lblIntentos.Text = intentos.ToString();
                    intentos++;
                    switch (intentos)
                    {
                        case 1:
                            this.pbImagen.Image = Resources.Imagen2;
                            break;
                        case 2:
                            this.pbImagen.Image = Resources.Imagen3;
                            break;
                        case 3:
                            this.pbImagen.Image = Resources.Imagen4;
                            break;
                        case 4:
                            this.pbImagen.Image = Resources.Imagen5;
                            break;
                        case 5:
                            this.pbImagen.Image = Resources.Imagen6;
                            break;
                    }
                }

                else contador = 0;

                if (intentos == 6)
                {
                    var result = MessageBox.Show($"Has Perdido, se te acabaron los intentos la palabra es:{word}, ¿Desea Volver a Jugar?", "Volver a Jugar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {


                        Play play = new Play();
                        play.Show();
                        this.Hide();
                    }
                    else
                    {
                        gana = 0;
                        intentos = 1;
                        lvLista.Items.Clear();
                        this.pbImagen.Image = Resources.Imagen1;
                        selectLista();
                        lblIntentos.Text = "";

                    }
                }
                if (gana == word.Length)
                {
                    var result = MessageBox.Show(" Has Ganado, Felicidades , ¿Desea Volver a Jugar?", "Volver a Jugar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {


                        Play play = new Play();
                        play.Show();
                        this.Hide();
                    }
                    else
                    {
                        gana = 0;
                        intentos = 1;
                        lvLista.Items.Clear();
                        this.pbImagen.Image = Resources.Imagen1;
                        selectLista();
                        lblIntentos.Text = "";


                    }
                }

            }
            else
            {
                MessageBox.Show("Debe Seleccionar una opcion", "Advertencia");
            }


        }

        #endregion




        public int selectLista()
        {

            Random r = new Random();
            num = r.Next(0, 9);
            lvLista.Items.Clear();
            ComboBoxItem selectCategoria = cboCategorias.SelectedItem as ComboBoxItem;
            switch (selectCategoria.Value)
            {
                case (int)Categorias.ANIMALES:
                    llenarListas(1);
                    for (int i = 0; i < 1; i++)
                    {
                        word = animals[num].Nombre.ToUpper();
                    }
                    lines = new char[word.Length];
                    for (int i = 0; i < word.Length; i++)
                    {
                        lines[i] = '_';

                        lvLista.Items.Add(lines[i].ToString());
                    }
                    break;
                case (int)Categorias.FRUTAS:
                    llenarListas(2);
                    for (int i = 0; i < 1; i++)
                    {
                        word = frutas[num].Nombre.ToUpper();
                    }
                    lines = new char[word.Length];
                    for (int i = 0; i < word.Length; i++)
                    {
                        lines[i] = '_';

                        lvLista.Items.Add(lines[i].ToString());
                    }
                    break;
                case (int)Categorias.CARROS:
                    llenarListas(3);
                    for (int i = 0; i < 1; i++)
                    {
                        word = carros[num].Nombre.ToUpper();
                    }
                    lines = new char[word.Length];
                    for (int i = 0; i < word.Length; i++)
                    {
                        lines[i] = '_';

                        lvLista.Items.Add(lines[i].ToString());
                    }
                    break;
                default:
                    MessageBox.Show("Debe Seleccionar una opcion", "Advertencia");
                    break;
            }
            if (selectCategoria.Value == null)
            {
                return 0;
            }
            return (int)selectCategoria.Value;
        }

        public void llenarListas(int tipoLista)
        {
            switch (tipoLista)
            {
                case 1:
                    #region Animales
                    Animal perro = new Animal("Perro");
                    Animal gato = new Animal("Gato");
                    Animal tortuga = new Animal("Tortuga");
                    Animal leon = new Animal("Leon");
                    Animal tigre = new Animal("Tigre");
                    Animal hormiga = new Animal("Hormiga");
                    Animal tiburon = new Animal("Tiburon");
                    Animal aguila = new Animal("Aguila");
                    Animal lagarto = new Animal("Lagarto");
                    Animal pez = new Animal("Pez");

                    animals.Add(perro);
                    animals.Add(gato);
                    animals.Add(tortuga);
                    animals.Add(leon);
                    animals.Add(tigre);
                    animals.Add(hormiga);
                    animals.Add(tiburon);
                    animals.Add(aguila);
                    animals.Add(lagarto);
                    animals.Add(pez);
                    #endregion
                    break;
                case 2:
                    #region Frutas
                    Frutas melon = new Frutas("Melon");
                    Frutas cereza = new Frutas("Cereza");
                    Frutas fresa = new Frutas("Fresa");
                    Frutas guayaba = new Frutas("Guayaba");
                    Frutas banana = new Frutas("Banana");
                    Frutas papaya = new Frutas("Papaya");
                    Frutas tamarindo = new Frutas("Tamarindo");
                    Frutas sandia = new Frutas("Sandia");
                    Frutas zapote = new Frutas("Zapote");
                    Frutas naranja = new Frutas("Naranja");

                    frutas.Add(melon);
                    frutas.Add(cereza);
                    frutas.Add(fresa);
                    frutas.Add(guayaba);
                    frutas.Add(banana);
                    frutas.Add(papaya);
                    frutas.Add(tamarindo);
                    frutas.Add(sandia);
                    frutas.Add(zapote);
                    frutas.Add(naranja);
                    #endregion
                    break;
                case 3:
                    #region Carros
                    Carro toyota = new Carro("Toyota");
                    Carro Kia = new Carro("Kia");
                    Carro Honda = new Carro("Honda");
                    Carro hyundai = new Carro("Hyundai");
                    Carro Mercedes = new Carro("Mercedes");
                    Carro Audi = new Carro("Audi");
                    Carro Lexus = new Carro("Lexus");
                    Carro BMW = new Carro("BMW");
                    Carro maserati = new Carro("Maserati");
                    Carro ford = new Carro("Ford");
                    Carro volvo = new Carro("Volvo");

                    carros.Add(toyota);
                    carros.Add(Kia);
                    carros.Add(Honda);
                    carros.Add(hyundai);
                    carros.Add(Mercedes);
                    carros.Add(Audi);
                    carros.Add(Lexus);
                    carros.Add(BMW);
                    carros.Add(maserati);
                    carros.Add(ford);
                    carros.Add(volvo);
                    #endregion
                    break;
            }
        }
        private void LoadComboBox()
        {

            ComboBoxItem opcionPorDefecto = new ComboBoxItem
            {
                Text = "Seleccione una opcion",
                Value = null
            };


            ComboBoxItem animalesOpcion = new ComboBoxItem
            {
                Text = "Animales",
                Value = (int)Categorias.ANIMALES
            };

            ComboBoxItem frutasOpcion = new ComboBoxItem
            {
                Text = "Frutas",
                Value = (int)Categorias.FRUTAS
            };

            ComboBoxItem carrosOpcion = new ComboBoxItem
            {
                Text = "Carros",
                Value = (int)Categorias.CARROS
            };

            cboCategorias.Items.Add(opcionPorDefecto);
            cboCategorias.Items.Add(animalesOpcion);
            cboCategorias.Items.Add(frutasOpcion);
            cboCategorias.Items.Add(carrosOpcion);
            cboCategorias.SelectedItem = opcionPorDefecto;


        }
        public void letters(object sender)
        {

            Button btn = sender as Button;
            char letter = Convert.ToChar(btn.Text);
            while (letter <= 'Z')
            {

                if (btn.Name == "btn" + letter)
                {
                    juego(letter);
                    break;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            isLoad = false;
            this.pbImagen.Image = Resources.Imagen1;

        }

        #region eventos click de los botones
        private void btnA_Click(object sender, EventArgs e)
        {
            letters(sender);

        }

        private void btnB_Click(object sender, EventArgs e)
        {
            letters(sender);
        }


        private void btnC_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            letters(sender);
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            letters(sender);
        }
        #endregion

        private void cboCategorias_TextChanged(object sender, EventArgs e)
        {
            if (!isLoad)
            {
                selectLista();

            }
            this.pbImagen.Image = Resources.Imagen1;
            lblIntentos.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lvLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
