﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unstable
{
    public partial class NowaGra : Form
    {
        private int włosy = 0; //
        private int skóra = 0; // zmienne odpowiadające za zmianę wyglądu gracza

        /// <summary> Umożliwia dostęp do danych zawartych w klasie Launcher.</summary>
        Launcher daneLauncher;

        public NowaGra(Launcher dane)
        {
            InitializeComponent();

            daneLauncher = dane;

            aktualizator.Enabled = true; 
        }

        private void NowaGra_Load(object sender, EventArgs e)
        {

        }

        private void buttonWróć_Click(object sender, EventArgs e)
        {
            MenuGlowne formaMenuGlowne = new MenuGlowne(daneLauncher);

            this.Close();                   
            formaMenuGlowne.Show();
        }

        private void gracz_Click(object sender, EventArgs e)
        {

        }

        private void buttonGoTest_Click(object sender, EventArgs e)
        {
            PrzywrócUstawieniaPoczątkowe();
            Uniwersalne metodaUniwersalne = new Uniwersalne(daneLauncher);
            Ekwipunek formaEkwipunek = new Ekwipunek(daneLauncher);
            metodaUniwersalne.liczStatystyki();
            formaEkwipunek.Show();
            formaEkwipunek.Close();
            _01Piwnica forma_01Piwnica = new _01Piwnica(daneLauncher);
            this.Close();
            forma_01Piwnica.Show();
        }

        private void button_KolorWłosów_Click(object sender, EventArgs e)
        {
            if (włosy > 0)
                włosy--;
            else
                włosy = 3;
        }

        private void buttonKolorWłosów__Click(object sender, EventArgs e)
        {
            if (włosy < 3)
                włosy++;
            else
                włosy = 0;
        }

        private void button_KolorSkóry_Click(object sender, EventArgs e)
        {
            if (skóra > 0)
                skóra--;
            else
                skóra = 4;
        }

        private void buttonKolorSkóry__Click(object sender, EventArgs e)
        {
            if (skóra < 4)
                skóra++;
            else
                skóra = 0;
        }

        private void aktualizator_Tick(object sender, EventArgs e)
        {
            switch (skóra)
            {
                case 0:
                    switch (włosy)
                    {
                        case 0: this.gracz.Image = daneLauncher.whiteBrownStand.Image; break;
                        case 1: this.gracz.Image = daneLauncher.whiteBlackStand.Image; break;
                        case 2: this.gracz.Image = daneLauncher.whiteBlondeStand.Image; break;
                        case 3: this.gracz.Image = daneLauncher.whiteRedStand.Image; break;
                    }
                    break;
                case 1:
                    switch (włosy)
                    {
                        case 0: this.gracz.Image = daneLauncher.blackBrownStand.Image; break;
                        case 1: this.gracz.Image = daneLauncher.blackBlackStand.Image; break;
                        case 2: this.gracz.Image = daneLauncher.blackBlondeStand.Image; break;
                        case 3: this.gracz.Image = daneLauncher.blackRedStand.Image; break;
                    }
                    break;
                case 2:
                    switch (włosy)
                    {
                        case 0: this.gracz.Image = daneLauncher.pinkBrownStand.Image; break;
                        case 1: this.gracz.Image = daneLauncher.pinkBlackStand.Image; break;
                        case 2: this.gracz.Image = daneLauncher.pinkBlondeStand.Image; break;
                        case 3: this.gracz.Image = daneLauncher.pinkRedStand.Image; break;
                    }
                    break;
                case 3:
                    switch (włosy)
                    {
                        case 0: this.gracz.Image = daneLauncher.yellowBrownStand.Image; break;
                        case 1: this.gracz.Image = daneLauncher.yellowBlackStand.Image; break;
                        case 2: this.gracz.Image = daneLauncher.yellowBlondeStand.Image; break;
                        case 3: this.gracz.Image = daneLauncher.yellowRedStand.Image; break;
                    }
                    break;
                case 4:
                    switch (włosy)
                    {
                        case 0: this.gracz.Image = daneLauncher.redBrownStand.Image; break;
                        case 1: this.gracz.Image = daneLauncher.redBlackStand.Image; break;
                        case 2: this.gracz.Image = daneLauncher.redBlondeStand.Image; break;
                        case 3: this.gracz.Image = daneLauncher.redRedStand.Image; break;
                    }
                    break;
            }
        }

        private void PrzywrócUstawieniaPoczątkowe()
        {
            daneLauncher.daneGracz = new Launcher.ZmiennePostaci();
            daneLauncher.daneBonusyGracz = new Launcher.ZmienneBonusów();

            for (int i = 0; i <= 99; i++)
            {
                if (i < 2)
                {
                    daneLauncher.daneStrzała[i] = new Launcher.ZmienneObiektów();
                    daneLauncher.daneStrzała[i].exists = false;
                }
                if (i < 5)
                {
                    daneLauncher.daneMob[i] = new Launcher.ZmiennePostaci();
                    daneLauncher.daneMob[i].exists = false;

                    daneLauncher.daneBonusyMob[i] = new Launcher.ZmienneBonusów();

                    daneLauncher.daneDrop[i] = new Launcher.ZmienneEkwipunku();
                }
                if (i < 47)
                {
                    daneLauncher.danePlecakSlot[i] = new Launcher.ZmienneEkwipunku();
                    daneLauncher.danePlecakSlot[i].exists = false;
                }

                daneLauncher.danePrzeszkoda[i] = new Launcher.ZmienneObiektów();
                daneLauncher.danePrzeszkoda[i].exists = false;
            }
        }
    }
}
