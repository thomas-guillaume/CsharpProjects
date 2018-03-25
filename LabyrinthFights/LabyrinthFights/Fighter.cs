using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthFights
{
    class Fighter
    {
        // Atributes
        public int life;
        private int degat;
        private bool carac;
        private Object arme;
        public int positionx;
        public int positiony;

        //Constructor

        public Fighter()
        {
            this.life = 100;
            this.degat = 10;
            this.arme = null; // Fighter spawn sans arme

            Random rand = new Random();
            int index = rand.Next(0, 2);
            if (index == 0)
                this.carac = false; // False pour défensif
            else
                this.carac = true; // True pour offensif
        }

        // Getters  

        public int getpointsVie()
        {
            return this.life;
        }

        public int getDegat()
        {
            return this.degat;
        }

        public Object getArme()
        {
            return this.arme;
        }

        public int getposX()
        {
            return this.positionx;
        }

        public int getposY()
        {
            return this.positiony;
        }

        public bool getCarac()
        {
            return this.carac;
        }

        //Setters

        public void setposX(int x)
        {
            this.positionx = x;
        }

        public void setposY(int y)
        {
            this.positiony = y;
        }

        public void setpointsVie(int pts)
        {
            this.life = pts;
        }

        public void setArme(Object arme)
        {
            this.arme = arme;
        }

        // Methods

        public void takeObject()
        {
            Object arme = new Object();
            if (this.arme == null)
            {
                this.arme = arme;
                this.degat += arme.getDammage();
            }
            if ( arme.getDammage() > this.arme.getDammage())
            {
                this.arme = arme;
                this.degat = 10 + arme.getDammage();
            }
        }


        public void attack(Fighter ennemy)
        {
            if (ennemy.getpointsVie() >= this.degat)
            {
                if(this.arme == null)
                {
                    ennemy.life = ennemy.life - this.degat;
                }
                else
                {
                    ennemy.life = ennemy.life - this.degat;
                    this.degat -= 1;
                    this.arme.setDammage(this.arme.getDammage() - 1);
                    if (this.arme.getDammage() == 0)
                        this.arme = null;
                }
            }
            else if (ennemy.getpointsVie() < this.degat)
            {
                if (this.arme == null)
                {
                    ennemy.life = 0;
                }
                else
                {
                    ennemy.life = 0;
                    this.degat -= 1;
                    this.arme.setDammage(this.arme.getDammage() - 1);
                    if (this.arme.getDammage() == 0)
                        this.arme = null;
                }
            }
        }
    }
}
