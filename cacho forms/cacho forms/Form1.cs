using System;
using System.Drawing;
using System.Windows.Forms;

namespace cacho_forms
{
    public partial class Form1 : Form
    {
        // VARIABLES Clases
     
        ControladorDados misDados = new ControladorDados();
        CalculadoraPuntajes misPuntajes = new CalculadoraPuntajes();

        // limitador casillas
        int jugadorActual = 1;

        bool usadoBalasJ1 = false;
        bool usadoTontasJ1 = false;
        bool usadoTrenesJ1 = false;
        bool usadoCuadrasJ1 = false;
        bool usadoQuinasJ1 = false;
        bool usadoSenasJ1 = false;
        bool usadoEscaleraJ1 = false;
        bool usadoFullJ1 = false;
        bool usadoPokerJ1 = false;
        bool usadoGrande1J1 = false;
        bool usadoGrande2J1 = false;

        bool usadoBalasJ2 = false;
        bool usadoTontasJ2 = false;
        bool usadoTrenesJ2 = false;
        bool usadoCuadrasJ2 = false;
        bool usadoQuinasJ2 = false;
        bool usadoSenasJ2 = false;
        bool usadoEscaleraJ2 = false;
        bool usadoFullJ2 = false;
        bool usadoPokerJ2 = false;
        bool usadoGrande1J2 = false;
        bool usadoGrande2J2 = false;

        string mejorJugadaActual = "";
        int mejorPuntajeActual = 0;
        public Form1()
        {
            InitializeComponent();

            jugadorActual = 1;
            lblMensaje.Text = "Jugador uno juega";
            lblMensaje.ForeColor = Color.Blue;
            ActualizarBotonesTurno();

            lblDormida.Text = "";
            lblDormida.ForeColor = Color.DarkRed;
        }
            private void MarcarMejorJugada()
        {
         
            LimpiarColoresBotones();

            mejorJugadaActual = "";
            mejorPuntajeActual = 0;

            // Calcular puntajes posibles
            int balas = misPuntajes.CalcularNumeros(misDados.Dados, 1);
            int tontas = misPuntajes.CalcularNumeros(misDados.Dados, 2);
            int trenes = misPuntajes.CalcularNumeros(misDados.Dados, 3);
            int cuadras = misPuntajes.CalcularNumeros(misDados.Dados, 4);
            int quinas = misPuntajes.CalcularNumeros(misDados.Dados, 5);
            int senas = misPuntajes.CalcularNumeros(misDados.Dados, 6);

            int escalera = misPuntajes.CalcularEscalera(misDados.Dados, misDados.FueDeMano, misDados.Tiros >=2);
            int full = misPuntajes.CalcularFull(misDados.Dados, misDados.FueDeMano, misDados.Tiros >=2);
            int poker = misPuntajes.CalcularPoker(misDados.Dados, misDados.FueDeMano, misDados.Tiros >=2);
            int grande = misPuntajes.CalcularGrande(misDados.Dados, misDados.FueDeMano, misDados.Tiros >=2);

            // Revisar según jugador actual y casillas disponibles
            if (jugadorActual == 1)
            {
                EvaluarMejor("Balas", balas, btnBalas, usadoBalasJ1);
                EvaluarMejor("Tontas", tontas, btnTontas, usadoTontasJ1);
                EvaluarMejor("Trenes", trenes, btnTrenes, usadoTrenesJ1);
                EvaluarMejor("Cuadras", cuadras, btnCuadras, usadoCuadrasJ1);
                EvaluarMejor("Quinas", quinas, btnQuinas, usadoQuinasJ1);
                EvaluarMejor("Senas", senas, btnSenas, usadoSenasJ1);

                EvaluarMejor("Escalera", escalera, btnEscalera, usadoEscaleraJ1);
                EvaluarMejor("Full", full, btnFull, usadoFullJ1);
                EvaluarMejor("Poker", poker, btnPoker, usadoPokerJ1);
                EvaluarMejor("Grande 1", grande, btnGrande1, usadoGrande1J1);
                EvaluarMejor("Grande 2", grande, btnGrande2, usadoGrande2J1);
            }
            else
            {
                EvaluarMejor("Balas", balas, btnBalasJ2, usadoBalasJ2);
                EvaluarMejor("Tontas", tontas, btnTontasJ2, usadoTontasJ2);
                EvaluarMejor("Trenes", trenes, btnTrenesJ2, usadoTrenesJ2);
                EvaluarMejor("Cuadras", cuadras, btnCuadrasJ2, usadoCuadrasJ2);
                EvaluarMejor("Quinas", quinas, btnQuinasJ2, usadoQuinasJ2);
                EvaluarMejor("Senas", senas, btnSenasJ2, usadoSenasJ2);

                EvaluarMejor("Escalera", escalera, btnEscaleraJ2, usadoEscaleraJ2);
                EvaluarMejor("Full", full, btnFullJ2, usadoFullJ2);
                EvaluarMejor("Poker", poker, btnPokerJ2, usadoPokerJ2);
                EvaluarMejor("Grande 1", grande, btnGrande1J2, usadoGrande1J2);
                EvaluarMejor("Grande 2", grande, btnGrande2J2, usadoGrande2J2);
            }

            lblMensaje.Text = $"Jugador {jugadorActual}: mejor jugada sugerida: {mejorJugadaActual} ({mejorPuntajeActual})";
        }

        private void EvaluarMejor(string nombreJugada, int puntos, Button boton, bool usado)
        {
            if (usado) return;

            if (puntos > mejorPuntajeActual)
            {
                mejorPuntajeActual = puntos;
                mejorJugadaActual = nombreJugada;
            }
        }

        private void LimpiarColoresBotones()
        {
            Button[] botones = {
        btnBalas, btnTontas, btnTrenes, btnCuadras, btnQuinas, btnSenas,
        btnEscalera, btnFull, btnPoker, btnGrande1, btnGrande2,

        btnBalasJ2, btnTontasJ2, btnTrenesJ2, btnCuadrasJ2, btnQuinasJ2, btnSenasJ2,
        btnEscaleraJ2, btnFullJ2, btnPokerJ2, btnGrande1J2, btnGrande2J2
    };

            foreach (Button boton in botones)
            {
                boton.BackColor = SystemColors.Control;
            }
        }

        private void PintarMejorJugada()
        {
            Button? botonMejor = null;

            if (jugadorActual == 1)
            {
                if (mejorJugadaActual == "Balas") botonMejor = btnBalas;
                else if (mejorJugadaActual == "Tontas") botonMejor = btnTontas;
                else if (mejorJugadaActual == "Trenes") botonMejor = btnTrenes;
                else if (mejorJugadaActual == "Cuadras") botonMejor = btnCuadras;
                else if (mejorJugadaActual == "Quinas") botonMejor = btnQuinas;
                else if (mejorJugadaActual == "Senas") botonMejor = btnSenas;
                else if (mejorJugadaActual == "Escalera") botonMejor = btnEscalera;
                else if (mejorJugadaActual == "Full") botonMejor = btnFull;
                else if (mejorJugadaActual == "Poker") botonMejor = btnPoker;
                else if (mejorJugadaActual == "Grande 1") botonMejor = btnGrande1;
                else if (mejorJugadaActual == "Grande 2") botonMejor = btnGrande2;
            }
            else
            {
                if (mejorJugadaActual == "Balas") botonMejor = btnBalasJ2;
                else if (mejorJugadaActual == "Tontas") botonMejor = btnTontasJ2;
                else if (mejorJugadaActual == "Trenes") botonMejor = btnTrenesJ2;
                else if (mejorJugadaActual == "Cuadras") botonMejor = btnCuadrasJ2;
                else if (mejorJugadaActual == "Quinas") botonMejor = btnQuinasJ2;
                else if (mejorJugadaActual == "Senas") botonMejor = btnSenasJ2;
                else if (mejorJugadaActual == "Escalera") botonMejor = btnEscaleraJ2;
                else if (mejorJugadaActual == "Full") botonMejor = btnFullJ2;
                else if (mejorJugadaActual == "Poker") botonMejor = btnPokerJ2;
                else if (mejorJugadaActual == "Grande 1") botonMejor = btnGrande1J2;
                else if (mejorJugadaActual == "Grande 2") botonMejor = btnGrande2J2;
            }

            if (botonMejor != null)
            {
                botonMejor.BackColor = Color.LightGreen;
            }
        }

        

               private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void chkdado3_CheckedChanged(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void button7_Click(object sender, EventArgs e) { }
        private void button11_Click(object sender, EventArgs e) { }

        //LANZAR DADOS
        private void btnLanzar_Click(object sender, EventArgs e)
        {

            if (misDados.Tiros >= 2)
            {
                btnLanzar.Enabled = false;
                lblMensaje.Text = $"Jugador {jugadorActual}: ya usaste ambos tiros. Marca una casilla.";
                return;
            }

            bool[] guardados = new bool[] {
                chkDado1.Checked, chkDado2.Checked, chkDado3.Checked, chkDado4.Checked, chkDado5.Checked
            };

            misDados.Lanzar(guardados);

            ActualizarImagenDado(pbDado1, misDados.Dados[0]);
            ActualizarImagenDado(pbDado2, misDados.Dados[1]);
            ActualizarImagenDado(pbDado3, misDados.Dados[2]);
            ActualizarImagenDado(pbDado4, misDados.Dados[3]);
            ActualizarImagenDado(pbDado5, misDados.Dados[4]);

            MarcarMejorJugada();
            PintarMejorJugada();

            if (misDados.Tiros >= 2)
            {
                btnLanzar.Enabled = false;
                lblMensaje.Text = $"Jugador {jugadorActual}: marca una casilla para terminar tu turno";
            }
            // Dormida
            if (misPuntajes.EsGrande(misDados.Dados) && misDados.FueDeMano)
            {
                lblMensaje.Text = $"¡DORMIDA! GANÓ EL JUGADOR {jugadorActual}.";
                lblMensaje.ForeColor = Color.Blue;

                lblDormida.Text = $"DORMIDA J{jugadorActual}";
                lblDormida.ForeColor = Color.Red;

                btnLanzar.Enabled = false;
                return;
            }

        }

        // turmo siguiente
        private void SiguienteTurno()
        {
            misDados.ResetearTurno();
            btnLanzar.Enabled = true;
            // Limpiar dados
            chkDado1.Checked = false;
            chkDado2.Checked = false;
            chkDado3.Checked = false;
            chkDado4.Checked = false;
            chkDado5.Checked = false;

            LimpiarColoresBotones();

            // Cambiar turno
            if (jugadorActual == 1)
            {
                jugadorActual = 2;
                lblMensaje.Text = "TURNO: JUGADOR 2";
                lblMensaje.ForeColor = Color.Red;
            }
            else
            {
                jugadorActual = 1;
                lblMensaje.Text = "TURNO: JUGADOR 1";
                lblMensaje.ForeColor = Color.Blue;
            }
            ActualizarBotonesTurno();
        }

        private void ActualizarBotonesTurno()
        {
            bool turnoJ1 = jugadorActual == 1;
            bool turnoJ2 = jugadorActual == 2;

            // Botones Jugador 1
            btnBalas.Enabled = turnoJ1 && !usadoBalasJ1;
            btnTontas.Enabled = turnoJ1 && !usadoTontasJ1;
            btnTrenes.Enabled = turnoJ1 && !usadoTrenesJ1;
            btnCuadras.Enabled = turnoJ1 && !usadoCuadrasJ1;
            btnQuinas.Enabled = turnoJ1 && !usadoQuinasJ1;
            btnSenas.Enabled = turnoJ1 && !usadoSenasJ1;
            btnEscalera.Enabled = turnoJ1 && !usadoEscaleraJ1;
            btnFull.Enabled = turnoJ1 && !usadoFullJ1;
            btnPoker.Enabled = turnoJ1 && !usadoPokerJ1;
            btnGrande1.Enabled = turnoJ1 && !usadoGrande1J1;
            btnGrande2.Enabled = turnoJ1 && !usadoGrande2J1;

            // Botones Jugador 2
            btnBalasJ2.Enabled = turnoJ2 && !usadoBalasJ2;
            btnTontasJ2.Enabled = turnoJ2 && !usadoTontasJ2;
            btnTrenesJ2.Enabled = turnoJ2 && !usadoTrenesJ2;
            btnCuadrasJ2.Enabled = turnoJ2 && !usadoCuadrasJ2;
            btnQuinasJ2.Enabled = turnoJ2 && !usadoQuinasJ2;
            btnSenasJ2.Enabled = turnoJ2 && !usadoSenasJ2;
            btnEscaleraJ2.Enabled = turnoJ2 && !usadoEscaleraJ2;
            btnFullJ2.Enabled = turnoJ2 && !usadoFullJ2;
            btnPokerJ2.Enabled = turnoJ2 && !usadoPokerJ2;
            btnGrande1J2.Enabled = turnoJ2 && !usadoGrande1J2;
            btnGrande2J2.Enabled = turnoJ2 && !usadoGrande2J2;
        }

        // casillas j1
        private void btnBalas_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 1);
            btnBalas.Text = $"Balas ({puntos})";
            usadoBalasJ1 = true;
            SiguienteTurno();
        }

        private void btnTontas_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 2);
            btnTontas.Text = $"Tontos ({puntos})";
            usadoTontasJ1 = true;
            SiguienteTurno();
        }

        private void btnTrenes_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 3);
            btnTrenes.Text = $"Trenes ({puntos})";
            usadoTrenesJ1 = true;
            SiguienteTurno();
        }

        private void btnCuadras_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 4);
            btnCuadras.Text = $"Cuadras ({puntos})";
            usadoCuadrasJ1 = true;
            SiguienteTurno();
        }

        private void btnQuinas_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 5);
            btnQuinas.Text = $"Quinas ({puntos})";
            usadoQuinasJ1 = true;
            SiguienteTurno();
        }

        private void btnSenas_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 6);
            btnSenas.Text = $"Senas ({puntos})";
            usadoSenasJ1 = true;
            SiguienteTurno();
        }

        private void btnEscalera_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularEscalera(misDados.Dados, misDados.FueDeMano, misDados.Tiros >= 2);
            btnEscalera.Text = $"Escalera ({puntos})";
            usadoEscaleraJ1 = true;
            SiguienteTurno();
        }

        private void btnFull_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularFull(misDados.Dados, misDados.FueDeMano, misDados.Tiros >= 2);
            btnFull.Text = $"Full ({puntos})";
            usadoFullJ1 = true;
            SiguienteTurno();
        }

        private void btnPoker_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularPoker(misDados.Dados, misDados.FueDeMano, misDados.Tiros >= 2);
            btnPoker.Text = $"Poker ({puntos})";
            usadoPokerJ1 = true;
            SiguienteTurno();
        }

        private void btnGrande1_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularGrande(misDados.Dados,misDados.FueDeMano, misDados.Tiros >=2);
            btnGrande1.Text = $"Grande ({puntos})";
            usadoGrande1J1 = true;
            SiguienteTurno();
        }

        private void btnGrande2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 2) return;
            int puntos = misPuntajes.CalcularGrande(misDados.Dados,misDados.FueDeMano, misDados.Tiros >=2);
            btnGrande2.Text = $"Grande ({puntos})";
            usadoGrande2J1 = true;
            SiguienteTurno();
        }

        // casillas j2
        private void btnBalasJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 1);
            btnBalasJ2.Text = $"Balas ({puntos})";
            usadoBalasJ2 = true;
            SiguienteTurno();
        }

        private void btnTontasJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 2);
            btnTontasJ2.Text = $"Tontos ({puntos})";
            usadoTontasJ2 = true;
            SiguienteTurno();
        }

        private void btnTrenesJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 3);
            btnTrenesJ2.Text = $"Trenes ({puntos})";
            usadoTrenesJ2 = true;
            SiguienteTurno();
        }

        private void btnCuadrasJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 4);
            btnCuadrasJ2.Text = $"Cuadras ({puntos})";
            usadoCuadrasJ2 = true;
            SiguienteTurno();
        }

        private void btnQuinasJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 5);
            btnQuinasJ2.Text = $"Quinas ({puntos})";
            usadoQuinasJ2 = true;
            SiguienteTurno();
        }

        private void btnSenasJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularNumeros(misDados.Dados, 6);
            btnSenasJ2.Text = $"Senas ({puntos})";
            usadoSenasJ2 = true;
            SiguienteTurno();
        }

        private void btnEscaleraJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularEscalera(misDados.Dados, misDados.FueDeMano, misDados.Tiros >= 2);
            btnEscaleraJ2.Text = $"Escalera ({puntos})";
            usadoEscaleraJ2 = true;
            SiguienteTurno();
        }

        private void btnFullJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularFull(misDados.Dados, misDados.FueDeMano, misDados.Tiros >= 2);
            btnFullJ2.Text = $"Full ({puntos})";
            usadoFullJ2 = true;
            SiguienteTurno();
        }

        private void btnPokerJ2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularPoker(misDados.Dados, misDados.FueDeMano, misDados.Tiros >= 2);
            btnPokerJ2.Text = $"Poker ({puntos})";
            usadoPokerJ2 = true;
            SiguienteTurno();
        }

        private void btnGrande1J2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularGrande(misDados.Dados,misDados.FueDeMano, misDados.Tiros >= 2);
            btnGrande1J2.Text = $"Grande ({puntos})";
            usadoGrande1J2 = true;
            SiguienteTurno();
        }

        private void btnGrande2J2_Click(object sender, EventArgs e)
        {
            if (jugadorActual == 1) return;
            int puntos = misPuntajes.CalcularGrande(misDados.Dados,misDados.FueDeMano, misDados.Tiros >=2 );
            btnGrande2J2.Text = $"Grande ({puntos})";
            usadoGrande2J2 = true;
            SiguienteTurno();
        }

        // agregado de imagenes
        private void ActualizarImagenDado(PictureBox pb, int valorDado)
        {
            switch (valorDado)
            {
                case 1: pb.Image = Properties.Resources.dado1; break;
                case 2: pb.Image = Properties.Resources.dado2; break;
                case 3: pb.Image = Properties.Resources.dado3; break;
                case 4: pb.Image = Properties.Resources.dado4; break;
                case 5: pb.Image = Properties.Resources.dado5; break;
                case 6: pb.Image = Properties.Resources.dado6; break;
            }
        }

      
    }
}