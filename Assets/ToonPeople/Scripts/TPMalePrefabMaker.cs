                                using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;




namespace ToonPeople
{
    [ExecuteInEditMode]
    [SelectionBase]
    public class TPMalePrefabMaker : MonoBehaviour
    {
        public bool allOptions;
        int hair;
        int chest;
        int legs;
        int feet;
        int tie;
        int jacket;
        public bool tieactive;
        public bool tieactivecolor;
        public bool glassesactive;
        public bool jacketactive;
        public bool hatactive;
        public bool beardactive;
        public bool haircoloractive;
        GameObject GOhead;
        GameObject GOheadsimple;
        GameObject GObeard;
        GameObject GObeardsimple;
        GameObject[] GOfeet;
        GameObject[] GOhair;
        GameObject[] GOchest;
        GameObject[] GOlegs;
        GameObject GOglasses;
        GameObject[] GOjackets;
        GameObject[] GOties;
        public Object[] MATSkins;
        public Object[] MATElderSkins;
        public Object[] MAThairA;
        public Object[] MAThairB;
        public Object[] MAThairC;
        public Object[] MAThairD;
        public Object[] MAThairE;
        public Object[] MAThairF;
        public Object[] MAThairG;
        public Object[] MATGlasses;
        public Object[] MATTshirt;
        public Object[] MATShirtA;
        public Object[] MATShirtB;
        public Object[] MATEyes;
        public Object[] MATJacket;
        public Object[] MATSweater;
        public Object[] MATLegs;
        public Object[] MATFeetA;
        public Object[] MATFeetB;
        public Object[] MATHatA;
        public Object[] MATHatB;
        public Object[] MATHatC;
        public Object[] MATBowtie;
        public Object[] MATTie;
        public Object[] MATBeard;
        Vector4 beard;
        public Material trans;
        public Object[] MATteeth;
        public bool elder;

        void Start()
        {
            allOptions = false;
        }

        void LateUpdate()
        {
            if (elder)
            {
                SkinnedMeshRenderer rendhead;
                GOhead = transform.Find("HEAD").gameObject as GameObject;
                rendhead = GOhead.GetComponent<SkinnedMeshRenderer>();
                rendhead.SetBlendShapeWeight(29, 100);
                SkinnedMeshRenderer rendbeard;
                GObeard = transform.Find("BEARD").gameObject as GameObject;
                rendbeard = GObeard.GetComponent<SkinnedMeshRenderer>();
                rendbeard.SetBlendShapeWeight(11, 100);
            }
        }

        public void Getready()

        {
            //load models
            GOhead = transform.Find("HEAD").gameObject as GameObject;
            GObeard = transform.Find("BEARD").gameObject as GameObject;
            GOheadsimple = transform.Find("HEADsimple").gameObject as GameObject;
            if (GOheadsimple == null) GOheadsimple = transform.Find("HEADelder").gameObject as GameObject;
            GOheadsimple.SetActive(false);
            GObeardsimple = transform.Find("BEARDsimple").gameObject as GameObject;
            GObeardsimple.SetActive(false);

            GOhair = new GameObject[10];
            GOchest = new GameObject[8];
            GOlegs = new GameObject[3];
            GOfeet = new GameObject[3];
            GOjackets = new GameObject[2];
            GOties = new GameObject[3];
            beardactive = true;
            beard = new Vector4(1, 1, 1, 1);

            string[] hairnames = new string[10] { "TPMHairA", "TPMHairB", "TPMHairC", "TPMHairD", "TPMHairE", "TPMHairF", "TPMHairG", "TPMHatA", "TPMHatB", "TPMHatC" };
            string[] chestnames = new string[8] { "CHEST", "TPMShirtAL", "TPMShirtAS", "TPMShirtBL", "TPMShirtBS", "TPMTshirtB", "TPMTshirtL", "TPMTshirtS" };
            string[] legnames = new string[3] { "LEGS", "TPMLegsL", "TPMLegsS" };
            string[] feetnames = new string[3] { "FEET", "TPMFeetA", "TPMFeetB" };
            string[] jacketnames = new string[2] { "TPMSuit", "TPMSweater" };
            string[] tiesnames = new string[3] { "TPMBowtie", "TPMTieL", "TPMTieS" };

            for (int forAUX = 0; forAUX < 10; forAUX++) GOhair[forAUX] = transform.Find(hairnames[forAUX]).gameObject as GameObject;
            for (int forAUX = 0; forAUX < 8; forAUX++) GOchest[forAUX] = transform.Find(chestnames[forAUX]).gameObject as GameObject;
            for (int forAUX = 0; forAUX < 3; forAUX++) GOlegs[forAUX] = transform.Find(legnames[forAUX]).gameObject as GameObject;
            for (int forAUX = 0; forAUX < 3; forAUX++) GOfeet[forAUX] = transform.Find(feetnames[forAUX]).gameObject as GameObject;
            for (int forAUX = 0; forAUX < 2; forAUX++) GOjackets[forAUX] = transform.Find(jacketnames[forAUX]).gameObject as GameObject;
            for (int forAUX = 0; forAUX < 3; forAUX++) GOties[forAUX] = transform.Find(tiesnames[forAUX]).gameObject as GameObject;
            GOglasses = transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject;

            if (GOfeet[0].activeSelf && GOfeet[1].activeSelf)
            {
                Randomize();
                elder = false;
                haircoloractive = true;
            }
            else
            {
                while (!GOhair[hair].activeSelf) hair++;
                while (!GOchest[chest].activeSelf) chest++;
                while (!GOlegs[legs].activeSelf) legs++;
                while (!GOfeet[feet].activeSelf) feet++;
                jacket = 2;
                if (GOjackets[0].activeSelf) jacket = 0; if (GOjackets[1].activeSelf) jacket = 1;
                tie = 3;
                for (int forAUX = 0; forAUX < 3; forAUX++)
                {
                    if (GOties[forAUX].activeSelf) tie = forAUX;
                }
                if (GOglasses.activeSelf) glassesactive = true;
                Checkties();
                Checkbeard();
                Checkelder();
            }
        }
        void ResetSkin()
        {
            string[] allskins = new string[8] { "TPMaleA0", "TPMaleB0", "TPMaleC0", "TPMaleD0", "TP_E_MaleA0", "TP_E_MaleB0", "TP_E_MaleC0", "TP_E_MaleD0" };
            Material headskin = MATSkins[0] as Material;

            Material[] AUXmaterials;
            int materialcount;
            AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
            materialcount = GOhead.GetComponent<Renderer>().sharedMaterials.Length;
            for (int forAUX2 = 0; forAUX2 < materialcount; forAUX2++)
                for (int forAUX3 = 0; forAUX3 < allskins.Length; forAUX3++)
                    for (int forAUX4 = 1; forAUX4 < MATSkins.Length + 1; forAUX4++)
                    {
                        if (AUXmaterials[forAUX2].name == allskins[forAUX3] + forAUX4)
                        {
                            headskin = AUXmaterials[forAUX2];
                        }
                    }
            //legs
            for (int forAUX = 0; forAUX < GOlegs.Length; forAUX++)
            {
                AUXmaterials = GOlegs[forAUX].GetComponent<Renderer>().sharedMaterials;
                materialcount = GOlegs[forAUX].GetComponent<Renderer>().sharedMaterials.Length;
                for (int forAUX2 = 0; forAUX2 < materialcount; forAUX2++)
                    for (int forAUX3 = 0; forAUX3 < 4; forAUX3++)
                        for (int forAUX4 = 1; forAUX4 < 5; forAUX4++)
                        {
                            if (AUXmaterials[forAUX2].name == allskins[forAUX3] + forAUX4)
                            {
                                AUXmaterials[forAUX2] = headskin;
                                GOlegs[forAUX].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
                            }
                        }
            }
            //chest
            for (int forAUX = 0; forAUX < GOchest.Length; forAUX++)
            {
                AUXmaterials = GOchest[forAUX].GetComponent<Renderer>().sharedMaterials;
                materialcount = GOchest[forAUX].GetComponent<Renderer>().sharedMaterials.Length;
                for (int forAUX2 = 0; forAUX2 < materialcount; forAUX2++)
                    for (int forAUX3 = 0; forAUX3 < 4; forAUX3++)
                        for (int forAUX4 = 1; forAUX4 < 5; forAUX4++)
                        {
                            if (AUXmaterials[forAUX2].name == allskins[forAUX3] + forAUX4)
                            {
                                AUXmaterials[forAUX2] = headskin;
                                GOchest[forAUX].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
                            }
                        }
            }
            //feet
            for (int forAUX = 0; forAUX < GOfeet.Length; forAUX++)
            {
                AUXmaterials = GOfeet[forAUX].GetComponent<Renderer>().sharedMaterials;
                materialcount = GOfeet[forAUX].GetComponent<Renderer>().sharedMaterials.Length;
                for (int forAUX2 = 0; forAUX2 < materialcount; forAUX2++)
                    for (int forAUX3 = 0; forAUX3 < 4; forAUX3++)
                        for (int forAUX4 = 1; forAUX4 < 5; forAUX4++)
                        {
                            if (AUXmaterials[forAUX2].name == allskins[forAUX3] + forAUX4)
                            {
                                AUXmaterials[forAUX2] = headskin;
                                GOfeet[forAUX].GetComponent<Renderer>().sharedMaterials = AUXmaterials;
                            }
                        }
            }
            haircoloractive = true;
        }
        void Deactivateall()
        {
            for (int forAUX = 0; forAUX < GOhair.Length; forAUX++) GOhair[forAUX].SetActive(false);
            for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) GOchest[forAUX].SetActive(false);
            for (int forAUX = 0; forAUX < GOlegs.Length; forAUX++) GOlegs[forAUX].SetActive(false);
            for (int forAUX = 0; forAUX < GOfeet.Length; forAUX++) GOfeet[forAUX].SetActive(false);
            for (int forAUX = 0; forAUX < GOjackets.Length; forAUX++) GOjackets[forAUX].SetActive(false);
            for (int forAUX = 0; forAUX < GOties.Length; forAUX++) GOties[forAUX].SetActive(false);
            GOglasses.SetActive(false);
            GObeard.SetActive(false);
            glassesactive = false;
            jacketactive = false;
            tieactivecolor = false;
            tieactive = false;
            tieactivecolor = false;
            hatactive = false;
        }
        void Activateall()
        {
            for (int forAUX = 0; forAUX < GOhair.Length; forAUX++) GOhair[forAUX].SetActive(true);
            for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) GOchest[forAUX].SetActive(true);
            for (int forAUX = 0; forAUX < GOlegs.Length; forAUX++) GOlegs[forAUX].SetActive(true);
            for (int forAUX = 0; forAUX < GOfeet.Length; forAUX++) GOfeet[forAUX].SetActive(true);
            for (int forAUX = 0; forAUX < GOjackets.Length; forAUX++) GOjackets[forAUX].SetActive(true);
            for (int forAUX = 0; forAUX < GOties.Length; forAUX++) GOties[forAUX].SetActive(true);
            GOglasses.SetActive(true);
            GObeard.SetActive(true);
        }
        public void Menu()
        {
            allOptions = !allOptions;
        }
        void Checkelder()
        {
            Material[] AUXmaterials;
            elder = false;
            haircoloractive = true;
            AUXmaterials = GOhead.GetComponent<Renderer>().sharedMaterials;
            int materialcount = GOhead.GetComponent<Renderer>().sharedMaterials.Length;
            for (int forAUX = 0; forAUX < materialcount; forAUX++)
            {
                if (AUXmaterials[forAUX].name == MATteeth[1].name)
                {
                    elder = true;
                    haircoloractive = false;
                }
            }
        }
        public void Checkties()
        {
            if (chest == 1 || chest == 2)
            {
                tieactive = true;
                if (tie != 0)
                {
                    GOties[tie - 1].SetActive(true);
                    tieactivecolor = true;
                }
                else tieactivecolor = false;
            }
            else
            {
                if (tie != 0) GOties[tie - 1].SetActive(false);
                tieactive = false;
                tieactivecolor = false;
            }
        }
        void Checkbeard()
        {
            if (GObeard.activeSelf)
            {
                beardactive = true;
                beard = new Vector4(1, 1, 1, 1);
                Material[] AUXmaterials;
                AUXmaterials = GObeard.GetComponent<Renderer>().sharedMaterials;
                if (AUXmaterials[0] == trans) beard.x = 0;
                if (AUXmaterials[1] == trans) beard.y = 0;
                if (AUXmaterials[2] == trans) beard.z = 0;
                if (AUXmaterials[3] == trans) beard.w = 0;
            }
            else beardactive = false;
        }


        //models
        public void Nexthat()
        {
            hatactive = true;
            if (hair < 7)
            {
                GOhair[hair].SetActive(false);
                hair = 7;
                GOhair[hair].SetActive(true);
            }
            else
            {
                GOhair[hair].SetActive(false);
                hair++;
                if (hair > GOhair.Length - 1) hair = 7;
                GOhair[hair].SetActive(true);
            }
        }
        public void Prevhat()
        {
            hatactive = true;
            if (hair < 7)
            {
                GOhair[hair].SetActive(false);
                hair = 9;
                GOhair[hair].SetActive(true);
            }
            else
            {
                GOhair[hair].SetActive(false);
                hair--;
                if (hair < 7) hair = 9;
                GOhair[hair].SetActive(true);
            }
        }
        public void Nexthair()
        {
            hatactive = false;

            GOhair[hair].SetActive(false);
            if (hair < GOhair.Length - 4) hair++;
            else hair = 0;
            GOhair[hair].SetActive(true); 
        }
        public void Sethair(int index)
        {
            GOhair[hair].SetActive(false);
            hair = index;
            GOhair[hair].SetActive(true);
            hatactive = false;
            if (hair > 6) hatactive = true;
        }
        public void GlassesOn()
        {
            glassesactive = !glassesactive;
            GOglasses.SetActive(glassesactive);
        }
        public void GlassesOff()
        {
            glassesactive = false;
            GOglasses.SetActive(glassesactive);
        }
        public void Nextchest()
        {
            GOchest[chest].SetActive(false);
            if (chest < GOchest.Length - 1) chest++;
            else chest = 0;
            GOchest[chest].SetActive(true);
            Checkties();
        }
        public void Setchest(int index)
        {
            GOchest[chest].SetActive(false);
            chest = index;
            GOchest[chest].SetActive(true);
            Checkties();
        }
        public void Nextlegs()
        {
            GOlegs[legs].SetActive(false);
            if (legs < GOlegs.Length - 1) legs++;
            else legs = 0;
            GOlegs[legs].SetActive(true);
        }
        public void Setlegs(int index)
        {
            GOlegs[legs].SetActive(false);
            legs = index;
            GOlegs[legs].SetActive(true);
        }
        public void Nextfeet()
        {
            GOfeet[feet].SetActive(false);
            if (feet < GOfeet.Length - 1) feet++;
            else feet = 0;
            GOfeet[feet].SetActive(true);
        }
        public void Setfeet(int index)
        {
            GOfeet[feet].SetActive(false);
            feet = index;
            GOfeet[feet].SetActive(true);
        }
        public void Nexttie()
        {
            if (tie != 0) GOties[tie - 1].SetActive(false);
            if (tie < GOties.Length) tie++;
            else tie = 0;
            if (tie != 0) GOties[tie - 1].SetActive(true);
            if (tie == 0) tieactivecolor = false;
            else tieactivecolor = true;
        }
        public void Prevtie()
        {
            if (tie != 0) GOties[tie - 1].SetActive(false);
            tie--;
            if (tie < 0) tie = 3;
            if (tie != 0) GOties[tie - 1].SetActive(true);
            if (tie == 0) tieactivecolor = false;
            else tieactivecolor = true;
        }
        public void Settie(int index)
        {
            if (tie != 0) GOties[tie - 1].SetActive(false);
            if (index == 2 && tie == 2) index = 3;
            else if (index == 2 && tie == 3) index = 2;
            if (index == 1 && tie == 1) index = 0;
            else if (index == 0 && tie == 1) index = 1;
            tie = index;
            if (index > 0)
                GOties[tie - 1].SetActive(true);
            Checkties();
        }
        public void Nextjacket()
        {
            if (jacket != 0)
                GOjackets[jacket - 1].SetActive(false);
            jacket++;
            if (jacket > GOjackets.Length) jacket = 0;
            if (jacket == 0)
            {
                jacketactive = false;
            }
            else
            {
                GOjackets[jacket - 1].SetActive(true);
                jacketactive = true;
            }
        }
        public void Prevjacket()
        {
            if (jacket != 0)
                GOjackets[jacket - 1].SetActive(false);
            jacket--;
            if (jacket < 0) jacket = GOjackets.Length;
            if (jacket == 0)
            {
                jacketactive = false;
            }
            else
            {
                GOjackets[jacket - 1].SetActive(true);
                jacketactive = true;
            }
        }
        public void Jacketon(int index)
        {
            if (index == jacket)
            {
                GOjackets[jacket - 1].SetActive(false);
                jacket = 0;
            }
            else
            {
                if (jacket > 0) GOjackets[jacket - 1].SetActive(false);
                jacket = index;
                GOjackets[jacket - 1].SetActive(true);
            }
        }
        public void Prevhair()
        {
            hatactive = false;
            GOhair[hair].SetActive(false);
            if (hair > 0) hair--;
            else hair = 6;
            GOhair[hair].SetActive(true);
        }
        public void Prevchest()
        {
            GOchest[chest].SetActive(false);
            chest--;
            if (chest < 0) chest = GOchest.Length - 1;
            GOchest[chest].SetActive(true);
            Checkties();
        }
        public void Prevlegs()
        {
            GOlegs[legs].SetActive(false);
            if (legs > 0) legs--;
            else legs = GOlegs.Length - 1;
            GOlegs[legs].SetActive(true);
        }
        public void Prevfeet()
        {
            GOfeet[feet].SetActive(false);
            if (feet > 0) feet--;
            else feet = GOfeet.Length - 1;
            GOfeet[feet].SetActive(true);
        }        

        public void BeardONOFF()
        {
            beardactive = !beardactive;
            GObeard.SetActive(beardactive);
            if (beardactive)
            {
                beard = new Vector4(1, 1, 1, 1);
                Setbeard();
            }
        }
        public void BeardON()
        {
            beardactive = true;
            GObeard.SetActive(beardactive);
            beard = new Vector4(1, 1, 1, 1);
            Setbeard();
        }
        public void BeardOFF()
        {
            beardactive = false;
            GObeard.SetActive(beardactive);
            beard = new Vector4(0, 0, 0, 0);            
        }
        public void Randombeard()
        {
            beard = new Vector4(1, 1, 1, 1);
            Setbeard();
            beard = new Vector4(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
            Setbeard();
        }
        public void BeardPart(int index)
        {
            beardactive = true;
            GObeard.SetActive(beardactive);
            int[] pro = new int[4] { (int)beard.x, (int)beard.y, (int)beard.z, (int)beard.w, };
            if (pro[index] == 0) pro[index] = 1;
            else pro[index] = 0;
            beard.x = pro[0]; beard.y = pro[1]; beard.z = pro[2]; beard.w = pro[3];
            Setbeard();
        }
        public void Setbeard()
        {
            Object[][] MatALLHairs = new Object[10][] { MAThairA, MAThairB, MAThairC, MAThairD, MAThairE, MAThairF, MAThairG, MAThairG, MAThairG, MAThairG };
            int MATindex = CheckMaterial(GOhair[hair], MatALLHairs[hair]);
            
            //int MATindex = 0;
            //Material Op;
            //Op = GOhair[0].GetComponent<Renderer>().sharedMaterial;
            //while (Op.name != MAThairA[MATindex].name) MATindex++;
            if (hair == 5) MATindex = 2;
            Material[] AUXmaterials;
            AUXmaterials = GObeard.GetComponent<Renderer>().sharedMaterials;
            if (beard.x == 0) AUXmaterials[0] = trans;
            else AUXmaterials[0] = MATBeard[MATindex] as Material;
            if (beard.y == 0) AUXmaterials[1] = trans;
            else AUXmaterials[1] = MATBeard[MATindex] as Material;
            if (beard.z == 0) AUXmaterials[2] = trans;
            else AUXmaterials[2] = MATBeard[MATindex] as Material;
            if (beard.w == 0) AUXmaterials[3] = trans;
            else AUXmaterials[3] = MATBeard[MATindex] as Material;
            GObeard.GetComponent<Renderer>().sharedMaterials = AUXmaterials;

            //beardsimple
            //AUXmaterials = GObeardsimple.GetComponent<Renderer>().sharedMaterials;
            GObeardsimple.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
        }
        public void BeardsStyles(int style)
        {
            beardactive = true;
            GObeard.SetActive(beardactive);
            Vector4[] Styles = new Vector4[8] { new Vector4(0, 0, 0, 0), new Vector4(1, 1, 1, 1), new Vector4(1,0,0,0), new Vector4(1, 1, 1, 0), new Vector4(0, 1, 1, 0), new Vector4(0, 0, 0, 1), new Vector4(1, 0, 0, 1), new Vector4(0, 0, 1, 1) };
            beard = Styles[style];
            Setbeard();
        }
        public void Sets(int setN)
        {
            int[] newset = new int[18];
            //set :   0_hair, 1_hair texture, 2_hat texture, 3_skin, 4_eyes,5_glasses, 6_glasses texture, 7_beard, 8_chest,
            //        9_texture, 10_tie, 11_texture, 12_jacket, 13_texture, 14_legs, 15_legs texture, 16_feet, 17_texture
            //                                    0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17  
            if (setN == 0) newset = new int[18] { 6, 25, 1, 25, 25, 0, 9, 0, 7, 8, 1, 6, 0, 0, 2, 14, 2, 2 };
            if (setN == 1) newset = new int[18] { 4, 25, 0, 25, 25, 1, 8, 0, 7, 4, 2, 7, 0, 0, 2, 6, 2, 4 };
            if (setN == 2) newset = new int[18] { 8, 25, 3, 25, 25, 0, 9, 0, 7, 1, 2, 7, 0, 0, 2, 12, 2, 3 };
            if (setN == 3) newset = new int[18] { 2, 25, 3, 25, 25, 0, 9, 0, 7, 10, 3, 0, 0, 0, 1, 6, 2, 9 };
            if (setN == 4) newset = new int[18] { 8, 25,10, 25, 25, 1, 8, 0, 7, 3, 3, 0, 0, 0, 2, 13, 2, 1 };

            if (setN == 5) newset = new int[18] { 9, 25, 3, 25, 25, 0, 9, 0, 3, 5, 1, 8, 0, 0, 1, 10, 1, 3 };
            if (setN == 6) newset = new int[18] { 4, 25, 2, 25, 25, 0, 8, 0, 4, 6, 3, 3, 0, 0, 2, 13, 2, 2 };
            if (setN == 7) newset = new int[18] { 6, 25, 2, 25, 25, 0, 9, 0, 4, 0, 0, 0, 0, 0, 1, 7, 1, 9 };
            if (setN == 8) newset = new int[18] { 3, 25, 0, 25, 25, 0, 9, 0, 5, 1, 3, 3, 2, 5, 1, 0, 2, 6 };
            if (setN == 9) newset = new int[18] { 1, 25, 2, 25, 25, 0, 8, 0, 6, 6, 2, 7, 1, 1, 1, 2, 1, 6 };

            if (setN == 10) newset = new int[18] { 1, 25, 3, 25, 25, 0, 9, 0, 5, 2, 1, 6, 1, 9, 1, 0, 1, 0 };
            if (setN == 11) newset = new int[18] { 3, 25, 3, 25, 25, 0, 8, 0, 3, 10, 0, 0, 1, 6, 1, 1, 1, 1 };
            if (setN == 12) newset = new int[18] { 4, 25, 3, 25, 25, 0, 9, 0, 1, 6, 2, 2, 1, 7, 1, 8, 1, 8 };
            if (setN == 13) newset = new int[18] { 6, 25, 3, 25, 25, 0, 9, 0, 5, 2, 2, 4, 1, 2, 1, 7, 1, 3 };
            if (setN == 14) newset = new int[18] { 0, 25, 3, 25, 25, 1, 9, 0, 1, 1, 2, 5, 1, 0, 1, 8, 1, 10 };




            SetSet(newset);
        }
        private void SetSet(int[] CharSet)
        {
            Deactivateall();
            ResetSkin();

            //set :   0_hair, 1_hair texture, 2_hat texture, 3_skin, 4_eyes,5_glasses, 6_glasses texture, 7_beard, 8_chest,
            //        9_texture, 10_tie, 11_texture, 12_jacket, 13_texture, 14_legs, 15_legs texture, 16_feet, 17_texture

            //skin
            ChangeMaterials(MATSkins, 3);
            if (CharSet[3] < 4)
                for (int forAUX = 0; forAUX < CharSet[3]; forAUX++) ChangeMaterials(MATSkins, 0);
            else
                for (int forAUX = 0; forAUX < Random.Range(0, 4); forAUX++) ChangeMaterials(MATSkins, 0);
                      
            //beard
            if (CharSet[7] > 0)
            {
                beardactive = true;
                GObeard.SetActive(true);
                Vector4[] Styles = new Vector4[8] { new Vector4(0, 0, 0, 0), new Vector4(1, 1, 1, 1), new Vector4(1, 0, 0, 0), new Vector4(1, 1, 1, 0), new Vector4(0, 1, 1, 0), new Vector4(0, 0, 0, 1), new Vector4(1, 0, 0, 1), new Vector4(0, 0, 1, 1) };
                if (CharSet[7] > 20)
                    Randombeard();
                else
                    beard = Styles[CharSet[7]];
            }
            else 
                beardactive = false;
            //hair
            hair = CharSet[0];
            GOhair[hair].SetActive(true);
            Object[][] MatALLHairs = new Object[12][] { MAThairA, MAThairB, MAThairC, MAThairD, MAThairE, MAThairF, MAThairG, MAThairC, MAThairC, MAThairC, MAThairA, MAThairA };
            //Object[][] MatALLBeards = new Object[12][] { MATBeard, MAThairB, MAThairC, MAThairD, MAThairE, MAThairF, MAThairG, MAThairC, MAThairC, MAThairC, MAThairA, MAThairA };
            if (beardactive)    Setbeard();

            if (CharSet[1] > 10)
            {
                int coin = Random.Range(0, 4);
                ChangeMaterial(GOhair[hair], MatALLHairs[hair], 6, coin);
                //ChangeMaterial(GObeard, MATBeard, 6, coin);
            }
            else
            {
                ChangeMaterial(GOhair[hair], MatALLHairs[hair], 6, CharSet[1]);
                //ChangeMaterial(GObeard, MATBeard, 6, CharSet[1]);
            }
            Setbeard();
            //hats
            if (CharSet[0] > 6)
            {
                hatactive = true;
                Object[][] MatALLHats = new Object[3][] { MATHatA, MATHatB, MATHatC };
                ChangeMaterial(GOhair[hair], MatALLHats[hair - 7], 6, CharSet[2]);
            }
            else hatactive = false;

            //eyes
            if (CharSet[4] > 10)
                ChangeMaterial(GOhead, MATEyes, 2, 0);

            else
                ChangeMaterial(GOhead, MATEyes, 6, CharSet[4]);

            //glasses
            if (CharSet[5] > 10) CharSet[5] = Random.Range(0, 2);
            if (CharSet[5] > 0)
            {
                GOglasses.SetActive(true);
                glassesactive = true;
                if (CharSet[6] > 10)
                    ChangeMaterial(GOglasses, MATGlasses, 2, 0);
                else
                    ChangeMaterial(GOglasses, MATGlasses, 6, CharSet[6]);
            }
            else glassesactive = false;

            //chest
            Object[][] MatALLChests = new Object[8][] { MATShirtA, MATShirtA, MATShirtA, MATShirtB, MATShirtB, MATTshirt, MATTshirt, MATTshirt };

            chest = CharSet[8];
            GOchest[chest].SetActive(true);
            ChangeMaterial(GOchest[chest], MatALLChests[chest], 6, CharSet[9]);

            //ties
            tie = CharSet[10];
            if (CharSet[10] > 0)
            {
                Object[][] MatALLTies = new Object[3][] { MATBowtie, MATTie, MATTie };
                GOties[tie - 1].SetActive(true);
                tieactive = true;
                ChangeMaterial(GOties[tie - 1], MatALLTies[tie - 1], 6, CharSet[11]);
            }
            else tieactive = false;


            //jacket
            jacket = CharSet[12];
            if (CharSet[12] > 0)
            {
                Object[][] MatALLjackets = new Object[2][] { MATJacket, MATSweater };
                GOjackets[jacket - 1].SetActive(true);
                ChangeMaterial(GOjackets[jacket - 1], MatALLjackets[jacket - 1], 6, CharSet[13]);
                if (jacket > 0) jacketactive = true;
            }
            else jacketactive = false;

            //legs
            Object[][] MatALLlegs = new Object[4][] { MATLegs, MATLegs, MATLegs, MATLegs };
            legs = CharSet[14];
            GOlegs[legs].SetActive(true);
            ChangeMaterial(GOlegs[legs], MatALLlegs[legs], 6, CharSet[15]);

            //feet
            Object[][] MatALLfeet = new Object[3][] { MATFeetA, MATFeetA, MATFeetB };
            feet = CharSet[16];
            GOfeet[feet].SetActive(true);
            ChangeMaterial(GOfeet[feet], MatALLfeet[feet], 6, CharSet[17]);

            Checkties();
            Checkelder();
        }
        public void CheckSet()
        {
            //set :   0_hair, 1_hair texture, 2_hat texture, 3_skin, 4_eyes,5_glasses, 6_glasses texture, 7_beard, 8_chest,
            //        9_texture, 10_tie, 11_texture, 12_jacket, 13_texture, 14_legs, 15_legs texture, 16_feet, 17_texture

            Object[][] MatALLHairs = new Object[12][] { MAThairA, MAThairB, MAThairC, MAThairD, MAThairE, MAThairF, MAThairG, MAThairC, MAThairC, MAThairC, MAThairA, MAThairA };
            Object[][] MatALLHats = new Object[10][] { MAThairA, MAThairB, MAThairC, MAThairD, MAThairE, MAThairF, MAThairG, MATHatA, MATHatB, MATHatC };
            Object[][] MatALLChests = new Object[8][] { MATShirtA, MATShirtA, MATShirtA, MATShirtB, MATShirtB, MATTshirt, MATTshirt, MATTshirt };
            Object[][] MatALLTies = new Object[3][] { MATBowtie, MATTie, MATTie };
            Object[][] MatALLjackets = new Object[2][] { MATJacket, MATSweater };
            Object[][] MatALLlegs = new Object[4][] { MATLegs, MATLegs, MATLegs, MATLegs };
            Object[][] MatALLfeet = new Object[3][] { MATFeetA, MATFeetA, MATFeetB };
            int glassesONOFF = 0; if (glassesactive) glassesONOFF = 1;

            //Debug.Log("hair " + hair);
            /*
            Debug.Log("Set:    " + hair + ", " + CheckMaterial(GOhair[hair], MatALLHairs[hair]) + ", " + CheckMaterial(GOhair[hair], MatALLHats[hair]) + ", " + CheckMaterial(GOhead, MATSkins) + ", " + CheckMaterial(GOhead, MATEyes) + ", " + glassesONOFF  ) ;

            Debug.Log("Set:    "  + CheckMaterial(GOglasses, MATGlasses) + ", 0, " + chest + ", " + CheckMaterial(GOchest[chest], MatALLChests[chest]) + ", " + tie + ", " + CheckMaterial(GOties[tie], MatALLTies[tie]));
            Debug.Log("Set:    " + jacket + ", " + CheckMaterial(GOjackets[jacket - 1], MatALLjackets[jacket - 1]) + ", " + legs + ", " + CheckMaterial(GOlegs[legs], MatALLlegs[legs]) + ", " + feet + ", " + CheckMaterial(GOfeet[feet], MatALLfeet[feet]));
            */
            int temptie = 0;
            if (tie > 0) temptie = CheckMaterial(GOties[tie - 1], MatALLTies[tie - 1]);
            int tempjacket = 0;
            if (jacket > 0) tempjacket = CheckMaterial(GOjackets[jacket - 1], MatALLjackets[jacket - 1]);
            Debug.Log("Set:    " + hair + ", " + CheckMaterial(GOhair[hair], MatALLHairs[hair]) + ", " + CheckMaterial(GOhair[hair], MatALLHats[hair]) + ", " + CheckMaterial(GOhead, MATSkins) + ", " + CheckMaterial(GOhead, MATEyes) + ", " + glassesONOFF + ", " + CheckMaterial(GOglasses, MATGlasses) + ", 0, " + chest + ", " + CheckMaterial(GOchest[chest], MatALLChests[chest]) + ", " + tie + ", " + temptie + ", " + jacket + ", " + tempjacket + ", " + legs + ", " + CheckMaterial(GOlegs[legs], MatALLlegs[legs]) + ", " + feet + ", " + CheckMaterial(GOfeet[feet], MatALLfeet[feet]));
        }

        //materials    
        public void Nexthatcolor(int todo)
        {
            if (hatactive)
            {
                if (hair == 7) ChangeMaterials(MATHatA, todo);
                if (hair == 8) ChangeMaterials(MATHatB, todo);
                if (hair == 9) ChangeMaterials(MATHatC, todo);
            }
        }
        public void Nextskincolor(int todo)
        {
            ChangeMaterials(MATSkins, todo);
            ChangeMaterials(MATElderSkins, todo);
        }
        public void Nexthaircolor(int todo)
        {
            if (!elder)
            {
                int intindex = 0;
                Material AUXmaterial;
                AUXmaterial = GOhair[0].GetComponent<Renderer>().sharedMaterial;
                while (AUXmaterial != MAThairA[intindex]) intindex++;
                if (intindex == 2 && todo == 0) todo = 3;
                if (intindex == 0 && todo == 1) todo = 4;

                ChangeMaterials(MAThairA, todo);
                ChangeMaterials(MAThairB, todo);
                ChangeMaterials(MAThairC, todo);
                ChangeMaterials(MAThairD, todo);
                ChangeMaterials(MAThairE, todo);
                ChangeMaterials(MAThairF, todo);
                ChangeMaterials(MAThairG, todo);
                Setbeard();
            }
        }
        public void Nextglasses(int todo)
        {
            ChangeMaterials(MATGlasses, todo);
        }
        public void Nexteyescolor(int todo)
        {
            ChangeMaterials(MATEyes, todo);
        }
        public void Nextchestcolor(int todo)
        {
            if (chest < 3) ChangeMaterials(MATShirtA, todo);
            if (chest > 2 && chest < 5) ChangeMaterials(MATShirtB, todo);
            if (chest > 4) ChangeMaterials(MATTshirt, todo);
        }
        public void Nextjacketcolor(int todo)
        {
            if (jacket == 1) ChangeMaterials(MATJacket, todo);
            if (jacket == 2) ChangeMaterials(MATSweater, todo);
        }
        public void Nextlegscolor(int todo)
        {
            ChangeMaterials(MATLegs, todo);
        }
        public void Nextfeetcolor(int todo)
        {
            if (feet == 1) ChangeMaterials(MATFeetA, todo);
            if (feet == 2) ChangeMaterials(MATFeetB, todo);
        }
        public void Nexttiecolor(int todo)
        {
            if (tie == 1) ChangeMaterials(MATBowtie, todo);
            if (tie > 1) ChangeMaterials(MATTie, todo);
        }
        public void ResetModel()
        {
            ElderOff();
            beard = new Vector4(1, 1, 1, 1);
            Activateall();
            ChangeMaterials(MATHatA, 3);
            ChangeMaterials(MATHatB, 3);
            ChangeMaterials(MATHatC, 3);
            ChangeMaterials(MATSkins, 3);
            ChangeMaterials(MAThairA, 3);
            ChangeMaterials(MAThairB, 3);
            ChangeMaterials(MAThairC, 3);
            ChangeMaterials(MAThairD, 3);
            ChangeMaterials(MAThairE, 3);
            ChangeMaterials(MAThairF, 3);
            ChangeMaterials(MAThairG, 3);
            Setbeard();
            ChangeMaterials(MATGlasses, 3);
            ChangeMaterials(MATEyes, 3);
            ChangeMaterials(MATShirtA, 3);
            ChangeMaterials(MATShirtB, 3);
            ChangeMaterials(MATTshirt, 3);
            ChangeMaterials(MATJacket, 3);
            ChangeMaterials(MATSweater, 3);
            ChangeMaterials(MATLegs, 3);
            ChangeMaterials(MATFeetA, 3);
            ChangeMaterials(MATFeetB, 3);
            ChangeMaterials(MATBowtie, 3);
            ChangeMaterials(MATTie, 3);
            ChangeMaterials(MATteeth, 3);
            Menu();
        }
        public void Randomize()
        {
            Deactivateall();
            ResetSkin();
            hair = Random.Range(0, 15);
            if (hair > 9) hair = Random.Range(0, 5);
            GOhair[hair].SetActive(true);
            if (hair > 5) hatactive = true;
            chest = Random.Range(1, GOchest.Length); GOchest[chest].SetActive(true);
            tie = Random.Range(0, 4);
            Checkties();
            legs = Random.Range(1, GOlegs.Length); GOlegs[legs].SetActive(true);
            feet = Random.Range(1, GOfeet.Length); GOfeet[feet].SetActive(true);
            jacket = Random.Range(0, GOjackets.Length + 1);
            if (jacket > 0)
            {
                jacketactive = true;
                GOjackets[jacket - 1].SetActive(true);
            }
            else jacketactive = false;
            if (Random.Range(0, 6) < 4) BeardON();
            else BeardOFF();
            if (Random.Range(0, 5) < 3 & beardactive) Randombeard();
            if (Random.Range(0, 4) > 2)
            {
                glassesactive = true;
                GOglasses.SetActive(true);
                ChangeMaterial(GOglasses, MATGlasses, 2, 0);
            }
            else glassesactive = false;

            //materials
            for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 4)); forAUX2++) Nextskincolor(0);
            for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 8)); forAUX2++) Nexthaircolor(0);
            if (tieactivecolor)
            {
                for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 10)); forAUX2++) Nexttiecolor(0);
            }
            for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 26)); forAUX2++) Nextjacketcolor(0);
            for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 34)); forAUX2++) Nextchestcolor(0);
            for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 32)); forAUX2++) Nextlegscolor(0);
            for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 26)); forAUX2++) Nextfeetcolor(0);
            for (int forAUX2 = 0; forAUX2 < (Random.Range(0, 24)); forAUX2++) Nexthatcolor(0);
            ChangeMaterial(GOhead, MATEyes, 2, 0);
        }
        public void CreateCopy()
        {
            GameObject newcharacter = Instantiate(gameObject, transform.position, transform.rotation);
            for (int forAUX = transform.childCount - 1; forAUX > 0; forAUX--)
            {
                if (!newcharacter.transform.GetChild(forAUX).gameObject.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(forAUX).gameObject);
            }
            if (!GObeard.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(0).gameObject);
            if (!GOglasses.activeSelf) DestroyImmediate(newcharacter.transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject);
            DestroyImmediate(newcharacter.GetComponent<TPMalePrefabMaker>());
        }
        public void FIX()
        {
            GameObject newcharacter = Instantiate(gameObject, transform.position, transform.rotation);
            if (transform.parent != null) newcharacter.transform.parent = transform.parent;
            for (int forAUX = transform.childCount - 1; forAUX > 0; forAUX--)
            {
                if (!newcharacter.transform.GetChild(forAUX).gameObject.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(forAUX).gameObject);
            }
            if (!GObeard.activeSelf) DestroyImmediate(newcharacter.transform.GetChild(0).gameObject);
            if (!GOglasses.activeSelf) DestroyImmediate(newcharacter.transform.Find("ROOT/TP/TP Pelvis/TP Spine/TP Spine1/TP Spine2/TP Neck/TP Head/Glasses").gameObject as GameObject);
            DestroyImmediate(newcharacter.GetComponent<TPMalePrefabMaker>());
            DestroyImmediate(gameObject);
        }
        public int CheckBodyPart(int wo)
        {
            //0_hair  1_chest  2_tie  3_jacket  4_legs  5_feet
            if (wo == 0) return hair;
            if (wo == 1) return chest;
            if (wo == 2) return tie;
            if (wo == 3) return jacket;
            if (wo == 4) return legs;
            if (wo == 5) return feet;
            else return 100;
        }

        public void ElderOn()
        {
            elder = true;
            haircoloractive = false;
            //blendshapes
            SkinnedMeshRenderer rendhead;
            rendhead = GOhead.GetComponent<SkinnedMeshRenderer>();
            rendhead.SetBlendShapeWeight(29, 100);
            SkinnedMeshRenderer rendbeard;
            rendbeard = GObeard.GetComponent<SkinnedMeshRenderer>();
            rendbeard.SetBlendShapeWeight(11, 100);

            //skin        
            SwitchMaterial(GOhead, MATSkins, MATElderSkins);
            for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) SwitchMaterial(GOchest[forAUX], MATSkins, MATElderSkins);
            for (int forAUX = 0; forAUX < GOlegs.Length; forAUX++) SwitchMaterial(GOlegs[forAUX], MATSkins, MATElderSkins);
            for (int forAUX = 0; forAUX < GOfeet.Length; forAUX++) SwitchMaterial(GOfeet[forAUX], MATSkins, MATElderSkins);


            //teeth
            ChangeMaterials(MATteeth, 1);

            //hair & beard        
            ChangeMaterials(MAThairA, 5);
            ChangeMaterials(MAThairB, 5);
            ChangeMaterials(MAThairC, 5);
            ChangeMaterials(MAThairD, 5);
            ChangeMaterials(MAThairE, 5);
            ChangeMaterials(MAThairF, 5);
            ChangeMaterials(MAThairG, 5);
            Setbeard();
        }
        public void ElderOff()

        {
            elder = false;
            haircoloractive = true;
            //blendshapes
            SkinnedMeshRenderer rendhead;
            rendhead = GOhead.GetComponent<SkinnedMeshRenderer>();
            rendhead.SetBlendShapeWeight(29, 0);
            SkinnedMeshRenderer rendbeard;
            rendbeard = GObeard.GetComponent<SkinnedMeshRenderer>();
            rendbeard.SetBlendShapeWeight(11, 0);

            //skin
            SwitchMaterial(GOhead, MATElderSkins, MATSkins);
            for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) SwitchMaterial(GOchest[forAUX], MATElderSkins, MATSkins);
            for (int forAUX = 0; forAUX < GOlegs.Length; forAUX++) SwitchMaterial(GOlegs[forAUX], MATElderSkins, MATSkins);
            for (int forAUX = 0; forAUX < GOfeet.Length; forAUX++) SwitchMaterial(GOfeet[forAUX], MATElderSkins, MATSkins);

            //teeth
            ChangeMaterials(MATteeth, 1);

            //hair & beard
            ChangeMaterials(MAThairA, 3);
            ChangeMaterials(MAThairB, 3);
            ChangeMaterials(MAThairC, 3);
            ChangeMaterials(MAThairD, 3);
            ChangeMaterials(MAThairE, 3);
            ChangeMaterials(MAThairF, 3);
            ChangeMaterials(MAThairG, 3);
            Setbeard();
        }
        public void Nude()
        {
            GOchest[chest].SetActive(false);
            GOlegs[legs].SetActive(false);
            GOfeet[feet].SetActive(false);
            chest = 0; legs = 0; feet = 0;
            GOchest[0].SetActive(true);
            GOlegs[0].SetActive(true);
            GOfeet[0].SetActive(true);
            if (jacket > 0) GOjackets[jacket -1].SetActive(false);
            jacketactive = false;
            jacket = 0;
            if (tie != 3) GOties[tie].SetActive(false);
            tie = 3;
            Checkties();
        }
      
        int CheckMaterial(GameObject GO, Object[] MAT)
        {
            int MATindex = 0;
            Material[] AUXmaterials;
            AUXmaterials = GO.GetComponent<Renderer>().sharedMaterials;
            int materialcount = GO.GetComponent<Renderer>().sharedMaterials.Length;

            for (int forAUX = 0; forAUX < materialcount; forAUX++)
                for (int forAUX2 = 0; forAUX2 < MAT.Length; forAUX2++)
                {
                    if (AUXmaterials[forAUX].name == MAT[forAUX2].name)
                        MATindex = forAUX2;
                }
            return MATindex;
        }
        void ChangeMaterial(GameObject GO, Object[] MAT, int todo, int newindex)
        {
            bool found = false;
            int MATindex = 0;
            int subMAT = 0;
            Material[] AUXmaterials;
            AUXmaterials = GO.GetComponent<Renderer>().sharedMaterials;
            int materialcount = GO.GetComponent<Renderer>().sharedMaterials.Length;

            for (int forAUX = 0; forAUX < materialcount; forAUX++)
                for (int forAUX2 = 0; forAUX2 < MAT.Length; forAUX2++)
                {
                    if (AUXmaterials[forAUX].name == MAT[forAUX2].name)
                    {
                        subMAT = forAUX;
                        MATindex = forAUX2;
                        found = true;
                    }
                }
            if (found)
            {
                if (todo == 0) //increase
                {
                    MATindex++;
                    if (MATindex > MAT.Length - 1) MATindex = 0;
                }
                if (todo == 1) //decrease
                {
                    MATindex--;
                    if (MATindex < 0) MATindex = MAT.Length - 1;
                }
                if (todo == 2) //random value
                {
                    MATindex = Random.Range(0, MAT.Length);
                }
                if (todo == 3) //reset value
                {
                    MATindex = 0;
                }
                if (todo == 4) //penultimate
                {
                    MATindex = MAT.Length - 2;
                }
                if (todo == 5) //last one
                {
                    MATindex = MAT.Length - 1;
                }
                else if (todo == 6) //choosen one
                {
                    MATindex = newindex;
                    if (newindex > MAT.Length) Debug.Log("Material index exsceeded");
                }
                AUXmaterials[subMAT] = MAT[MATindex] as Material;
                GO.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
            }
        }
        void ChangeMaterials(Object[] MAT, int todo)
        {
            for (int forAUX = 0; forAUX < GOhair.Length; forAUX++) ChangeMaterial(GOhair[forAUX], MAT, todo, 0);
            ChangeMaterial(GOhead, MAT, todo, 0);
            ChangeMaterial(GOglasses, MAT, todo, 0);
            ChangeMaterial(GOheadsimple, MAT, todo, 0);
            ChangeMaterial(GObeard, MAT, todo, 0);
            for (int forAUX = 0; forAUX < GOjackets.Length; forAUX++) ChangeMaterial(GOjackets[forAUX], MAT, todo, 0);
            for (int forAUX = 0; forAUX < GOties.Length; forAUX++) ChangeMaterial(GOties[forAUX], MAT, todo, 0);
            for (int forAUX = 0; forAUX < GOchest.Length; forAUX++) ChangeMaterial(GOchest[forAUX], MAT, todo, 0);
            for (int forAUX = 0; forAUX < GOlegs.Length; forAUX++) ChangeMaterial(GOlegs[forAUX], MAT, todo, 0);
            for (int forAUX = 0; forAUX < GOfeet.Length; forAUX++) ChangeMaterial(GOfeet[forAUX], MAT, todo, 0);
        }
        void SwitchMaterial(GameObject GO, Object[] MAT1, Object[] MAT2)
        {
            Material[] AUXmaterials;
            AUXmaterials = GO.GetComponent<Renderer>().sharedMaterials;
            int materialcount = GO.GetComponent<Renderer>().sharedMaterials.Length;

            for (int forAUX = 0; forAUX < materialcount; forAUX++)
                for (int forAUX2 = 0; forAUX2 < MAT1.Length; forAUX2++)
                {
                    if (AUXmaterials[forAUX].name == MAT1[forAUX2].name)
                    {
                        AUXmaterials[forAUX] = MAT2[forAUX2] as Material;
                        GO.GetComponent<Renderer>().sharedMaterials = AUXmaterials;
                    }
                }
        }
    }
}