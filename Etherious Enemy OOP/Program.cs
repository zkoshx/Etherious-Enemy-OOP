﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Etherious_Enemy_OOP
{
    class basicenemy
    {
        public string name;
        public int HP { get; }
        public int AP { get; }
        public int DF { get; }
        public int LV { get; }

     
        public basicenemy(int _HP, int _AP, int _DF, int _LV)
        {
            HP = _HP;
            AP = _AP;
            DF = _DF;
            LV = _LV;
        }

        public string[] phrases = new string[99];
        public string[] quotes = new string[99];
        public string sphrase;
        public string squote;

        public void check()
        {
            Console.WriteLine(name);
            Console.WriteLine("HP - " + HP);
            Console.WriteLine("AP - " + AP);
            Console.WriteLine("DF - " + DF);
            Console.WriteLine("LV - " + LV);
        }
    }

    class Enemy_1 : basicenemy
    {
        
        public Enemy_1(int hp, int ap, int df, int lv) : base(hp, ap, df, lv)
        {

            maxHP = hp;
            name = "Froggit";
            phrases[0] = "Froggit hopped close!";
            phrases[1] = "You are intimidated by Froggit's raw strength. Just kidding.";
            phrases[2] = "Froggit is looking for a fly";
            phrases[3] = "Froggit hops to and fro";
            phrases[4] = "Froggit doesn't seem to know why it's here";
            phrases[5] = "Froggit is trying to hop away";
            phrases[6] = "Froggit seems reluctant to fight you";

            quotes[0] = "Ribbit ribbit.";
            quotes[1] = "Croak croak.";
            quotes[2] = "Meow.";
            quotes[3] = "(Blushes deeply) Ribbit...";
            quotes[4] = "Shiver shiver.";
            resetstack();
        }
        int maxHP;
        public void WhatAreMyActions()
        {
            Console.WriteLine("Check");
            Console.WriteLine("Threaten");
            Console.WriteLine("Compliment");
            Console.WriteLine("Mystify");
        }

        public void Threaten()
        {
            sphrase = "You threatened the Froggit";
            squote = quotes[4];
            if (sparesequence.Peek().ToString() == "Threaten")
            {
                sparesequence.Pop();
            }
            else
            {
                resetstack();
            }
        }
        public void Compliment()
        {
            sphrase = "You told Froggit that it looks nice today";
            squote = quotes[3];
            if (sparesequence.Peek().ToString() == "Compliment")
            {
                sparesequence.Pop();
            }
            else
            {
                resetstack();
            }
        }
        public void Mystify()
        {
            sphrase = phrases[4];
            squote = quotes[2];
            if (sparesequence.Peek().ToString() == "Mystify")
            {
                sparesequence.Pop();
            }
            else
            {
                resetstack();
            }
        }
        public void resetstack()
        {
            sparesequence.Clear();
            sparesequence.Push("Threaten");
            sparesequence.Push("Compliment");
            sparesequence.Push("Mystify");
        }
        Stack sparesequence = new Stack();

        public void viewstack(Stack stack)
        {
            stack.ToArray();
        }


        public void ping(string path, int mdr, Random rnd)
        {
            if (path == "Neutral" || path == "Pacifist" || path == "Genocide")
            {
                if (sphrase is null && squote is null)
                {
                    if (HP < maxHP / 4)
                    {
                        sphrase = phrases[rnd.Next(5, 7)];
                        squote = quotes[rnd.Next(3)];
                    }
                    else
                    {
                        sphrase = phrases[rnd.Next(1, 5)];
                        squote = quotes[rnd.Next(3)];
                    }
                }
                else
                {
                    if (sparesequence.Count == 0)
                    {
                        //is spareable
                    }
                }
               
            }
        }
    }


    class Program
        {
        static void Main(string[] args)
        {
            Random pinger = new Random();

            List<basicenemy> encountered = new List<basicenemy>();

            Enemy_1 test = new Enemy_1(3, 4, 3, 4);
            ACT(test);


            static void ACT(Enemy_1 test)
            {
                Console.WriteLine("ACT");
                test.WhatAreMyActions();
                string input = Console.ReadLine();
                input = input.ToLower();
                switch (input)
                {
                    case ("compliment"):
                        test.Compliment();
                        break;

                    case ("threaten"):
                        test.Threaten();
                        break;

                    case ("mystify"):
                        test.Mystify();
                        break;

                    case ("check"):
                        test.check();
                        break;

                    default:
                        ACT(test);
                        break;

                }

                
            }
            
            string path = "Neutral";
            int mdr;

            
            
        }
    }
}

