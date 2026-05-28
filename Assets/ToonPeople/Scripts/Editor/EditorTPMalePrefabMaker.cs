using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ToonPeople
{
    [CustomEditor(typeof(TPMalePrefabMaker))]

    public class EditorTPMalePrefabMaker : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            TPMalePrefabMaker myPrefabMaker = (TPMalePrefabMaker)target;
            if (!myPrefabMaker.allOptions)
            {
                if (GUILayout.Button("LET'S GET DRESS", GUILayout.Width(250), GUILayout.Height(75)))
                {
                    myPrefabMaker.Menu();
                    myPrefabMaker.Getready();
                }
            }

            else
            {
                if (GUILayout.Button("RANDOMIZE", GUILayout.Width(250), GUILayout.Height(75)))
                {
                    myPrefabMaker.Randomize();
                }

                EditorGUILayout.Space();
                EditorGUILayout.LabelField("SETS", GUILayout.Width(65), GUILayout.Height(20));

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("1", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(0); }
                if (GUILayout.Button("2", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(1); }
                if (GUILayout.Button("3", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(2); }
                if (GUILayout.Button("4", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(3); }
                if (GUILayout.Button("5", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(4); }

                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("1", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(5); }
                if (GUILayout.Button("2", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(6); }
                if (GUILayout.Button("3", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(7); }
                if (GUILayout.Button("4", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(8); }
                if (GUILayout.Button("5", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(9); }

                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("1", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(10); }
                if (GUILayout.Button("2", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(11); }
                if (GUILayout.Button("3", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(12); }
                if (GUILayout.Button("4", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(13); }
                if (GUILayout.Button("5", GUILayout.Width(18), GUILayout.Height(18))) { myPrefabMaker.Sets(14); }

                GUILayout.EndHorizontal();

                //if (GUILayout.Button("TestSet", GUILayout.Width(60), GUILayout.Height(18))) { myPrefabMaker.CheckSet(); }


                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Prevhat(); }
                EditorGUILayout.LabelField("   HAT", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexthat(); }
                if (myPrefabMaker.hatactive)
                {
                    if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexthatcolor(1); }
                    EditorGUILayout.LabelField("  material", GUILayout.Width(65), GUILayout.Height(20));
                    if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexthatcolor(0); }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Prevhair(); }
                EditorGUILayout.LabelField("  HAIR", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexthair(); }
                if (myPrefabMaker.haircoloractive)
                {
                    if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexthaircolor(1); }
                    EditorGUILayout.LabelField("  material", GUILayout.Width(65), GUILayout.Height(20));
                    if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexthaircolor(0); }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextskincolor(1); }
                EditorGUILayout.LabelField("  SKIN", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextskincolor(0); }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexteyescolor(1); }
                EditorGUILayout.LabelField("  EYES", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexteyescolor(0); }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("GLASSES", GUILayout.Width(115), GUILayout.Height(20))) { myPrefabMaker.GlassesOn(); }
                if (myPrefabMaker.glassesactive)
                {
                    if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextglasses(1); }
                    EditorGUILayout.LabelField("  material", GUILayout.Width(65), GUILayout.Height(20));
                    if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextglasses(0); }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("BEARD", GUILayout.Width(115), GUILayout.Height(20))) { myPrefabMaker.BeardONOFF(); }
                if (myPrefabMaker.beardactive)
                {
                    if (GUILayout.Button("randomize", GUILayout.Width(115), GUILayout.Height(20))) { myPrefabMaker.Randombeard(); }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("1", GUILayout.Width(25), GUILayout.Height(20))) { myPrefabMaker.BeardsStyles(1); }
                if (GUILayout.Button("2", GUILayout.Width(25), GUILayout.Height(20))) { myPrefabMaker.BeardsStyles(2); }
                if (GUILayout.Button("3", GUILayout.Width(25), GUILayout.Height(20))) { myPrefabMaker.BeardsStyles(3); }
                if (GUILayout.Button("4", GUILayout.Width(25), GUILayout.Height(20))) { myPrefabMaker.BeardsStyles(4); }
                if (GUILayout.Button("5", GUILayout.Width(25), GUILayout.Height(20))) { myPrefabMaker.BeardsStyles(5); }
                if (GUILayout.Button("6", GUILayout.Width(25), GUILayout.Height(20))) { myPrefabMaker.BeardsStyles(6); }
                if (GUILayout.Button("7", GUILayout.Width(25), GUILayout.Height(20))) { myPrefabMaker.BeardsStyles(7); }
                GUILayout.EndHorizontal();
                


                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Prevjacket(); }
                EditorGUILayout.LabelField(" JACKET", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextjacket(); }
                if (myPrefabMaker.jacketactive)
                {
                    if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextjacketcolor(1); }
                    EditorGUILayout.LabelField("  material", GUILayout.Width(65), GUILayout.Height(20));
                    if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextjacketcolor(0); }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Prevchest(); }
                EditorGUILayout.LabelField("   CHEST", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextchest(); }
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextchestcolor(1); }
                EditorGUILayout.LabelField("  material", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextchestcolor(0); }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (myPrefabMaker.tieactive)
                {
                    if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Prevtie(); }
                    EditorGUILayout.LabelField("     TIE", GUILayout.Width(65), GUILayout.Height(20));
                    if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexttie(); }
                    if (myPrefabMaker.tieactivecolor)
                    {
                        if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexttiecolor(1); }
                        EditorGUILayout.LabelField("  material", GUILayout.Width(65), GUILayout.Height(20));
                        if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nexttiecolor(0); }
                    }
                }
                else EditorGUILayout.LabelField("        ", GUILayout.Width(115), GUILayout.Height(20));
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Prevlegs(); }
                EditorGUILayout.LabelField("    LEGS", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextlegs(); }
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextlegscolor(1); }
                EditorGUILayout.LabelField("  material", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextlegscolor(0); }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Prevfeet(); }
                EditorGUILayout.LabelField("    FEET", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextfeet(); }
                if (GUILayout.Button("<", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextfeetcolor(1); }
                EditorGUILayout.LabelField("  material", GUILayout.Width(65), GUILayout.Height(20));
                if (GUILayout.Button(">", GUILayout.Width(20), GUILayout.Height(20))) { myPrefabMaker.Nextfeetcolor(0); }
                GUILayout.EndHorizontal();

                if (GUILayout.Button("NUDE", GUILayout.Width(100), GUILayout.Height(25))) myPrefabMaker.Nude();

                if (myPrefabMaker.elder)
                {
                    if (GUILayout.Button("ELDER OFF", GUILayout.Width(100), GUILayout.Height(25)))
                    {
                        myPrefabMaker.ElderOff();
                    }
                }
                else if (GUILayout.Button("ELDER ON", GUILayout.Width(100), GUILayout.Height(25)))
                {
                    myPrefabMaker.ElderOn();
                }


                GUILayout.BeginHorizontal("box");
                if (GUILayout.Button("CREATE COPY", GUILayout.Width(100), GUILayout.Height(50)))
                {
                    myPrefabMaker.CreateCopy();
                }
                if (GUILayout.Button("DONE", GUILayout.Width(100), GUILayout.Height(50)))
                {
                    myPrefabMaker.FIX();
                }
                GUILayout.EndHorizontal();

                if (GUILayout.Button("RESET", GUILayout.Width(100), GUILayout.Height(50)))
                {
                    myPrefabMaker.ResetModel();
                }
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(myPrefabMaker);
        }
    }
}
