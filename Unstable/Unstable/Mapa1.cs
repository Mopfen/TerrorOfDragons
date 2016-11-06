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
    public partial class Mapa1 : Form
    {
        /// <summary> Umożliwia dostęp do danych zawartych w klasie Launcher.</summary>
        Launcher daneLauncher;

        public Mapa1(Launcher dane)
        {
            InitializeComponent();

            daneLauncher = dane;

            this.poleGry.Location = new System.Drawing.Point(3, -3);

            DoubleBuffered = true;

            timerGracz.Enabled = true;
            timerAtakGracz.Enabled = true;
            timerStatystyki.Enabled = true;
            timerMob.Enabled = true;
            timerAtakMob.Enabled = true;
            timerStrzałaGracz.Enabled = true;

            //for(int i=0;i<9;i++) daneLauncher.daneMob[i] = new Launcher();

            daneLauncher.daneGracz[0].obraz=gracz;
            daneLauncher.daneGracz[0].antyRozmycie = underGracz;
            daneLauncher.poleGry = poleGry;
            daneLauncher.daneMob[0].alive = true;
            daneLauncher.daneMob[0].antyRozmycie = underMob;
            daneLauncher.daneMob[0].obraz = mob;
            daneLauncher.daneMob[0].labelhp = labelHpMob0;
            daneLauncher.hitLog = hitLog;

            daneLauncher.daneGracz[0].hp = 100;
            daneLauncher.daneGracz[0].hpMax = 100;
            daneLauncher.daneGracz[0].mana = 100;
            daneLauncher.daneGracz[0].manaMax = 100;

            daneLauncher.daneMob[0].hp = 100;
            daneLauncher.daneMob[0].hpMax = 100;

            daneLauncher.daneStrzała[0].obraz = strzałaGracz;
            daneLauncher.daneStrzała[0].obraz.Visible = false;

            daneLauncher.music.SoundLocation = "Soundtrack1.wav";
            daneLauncher.music.PlayLooping();
        }

        private void Mapa1_KeyDown(object sender, KeyEventArgs e)
        {
            MetodyMap metodaMap = new MetodyMap(daneLauncher);
            metodaMap.KeyDownMetoda(this, e);
        }
        private void Mapa1_KeyUp(object sender, KeyEventArgs e)
        {
            MetodyMap metodaMap = new MetodyMap(daneLauncher);
            metodaMap.KeyUpMetoda(e);
        }
        private void timerGracz_Tick(object sender, EventArgs e)
        {
            Uniwersalne metodaUniwersalne = new Uniwersalne(daneLauncher);
            metodaUniwersalne.przeszkodaNaDrodze(daneLauncher.daneGracz[0], daneLauncher.daneMob[0]);

            MetodyMap metodaMap = new MetodyMap(daneLauncher);
            metodaMap.timerGraczMetoda();
        }
        private void timerAtakGracz_Tick(object sender, EventArgs e)
        {
            MetodyMap metodaMap = new MetodyMap(daneLauncher);
            metodaMap.timerAtakGraczMetoda(timerGracz);
        }
        private void timerStatystyki_Tick(object sender, EventArgs e)
        {
            Uniwersalne metodaUniwersalne = new Uniwersalne(daneLauncher);
            MetodyMap metodaMap = new MetodyMap(daneLauncher);
            labelHpMob0.Text = Convert.ToString(metodaUniwersalne.wyliczProcent(daneLauncher.daneMob[0].hp, daneLauncher.daneMob[0].hpMax)+"%");
            metodaMap.timerStatystykiMetoda(this, timerGracz, timerAtakGracz, timerMob, timerAtakMob, timerStatystyki, labelHpGracz, labelManaGracz, labelLvGracz, labelExpGracz);
        }

        private void timerMob_Tick(object sender, EventArgs e)
        {
            Mob metodaMob = new Mob(daneLauncher);
            metodaMob.RuchMobaDoGracza(0);
        }

        private void timerAtakMob_Tick(object sender, EventArgs e)
        {
            Mob metodaMob = new Mob(daneLauncher);
            metodaMob.AtakMoba(timerMob, 0,5);
        }

        private void timerStrzałaGracz_Tick(object sender, EventArgs e)
        {
            MetodyMap metodaMap = new MetodyMap(daneLauncher);
            metodaMap.timerStrzałaGraczMetoda(1,0,0,0);
        }
    }
}
