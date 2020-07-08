using KartGame.KartSystems;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace GetaKarts.GetaEditor
{
    public class KartStatsEditor : EditorWindow
    {
        private ArcadeKart kart;
        private ArcadeKart.Stats stats;
        private Editor kartEditor;
        private Vector2 statsScrollPos;

        private GUIStyle titleStyle;

        private GUIStyle TitleStyle
        {
            get
            {
                if (titleStyle == null)
                {
                    titleStyle = new GUIStyle(Application.HasProLicense() ? EditorStyles.whiteLabel : EditorStyles.label);
                    titleStyle.alignment = TextAnchor.MiddleCenter;
                    titleStyle.fontStyle = FontStyle.Bold;
                }

                return titleStyle;
            }
        }

        [MenuItem("Geta Karts/Edit Stats")]
        public static void ShowWindow()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(KartStatsEditor), true, "Kart Stats Editor", true);
            window.minSize = new Vector2(500, 250);
            window.maxSize = new Vector2(500, 400);
        }

        private void OnGUI()
        {
            ShowKartSelector();
            
            if (kart != null)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Stats", TitleStyle);

                statsScrollPos = EditorGUILayout.BeginScrollView(statsScrollPos);
                DisplayStats();
                EditorGUILayout.EndScrollView();

                EditorGUILayout.BeginHorizontal();

                if (GUILayout.Button("Save"))
                    kart.baseStats = stats;
                
                if (GUILayout.Button("Discard"))
                    stats = kart.baseStats;

                if (GUILayout.Button("Reset Defaults"))
                    SetDefaultStats();

                EditorGUILayout.EndHorizontal();
            }
        }

        private void DisplayStats()
        {
            stats.TopSpeed = DrawFloatField(stats.GetType().GetField("TopSpeed"), stats);
            stats.Acceleration = DrawFloatField(stats.GetType().GetField("Acceleration"), stats);
            stats.AccelerationCurve = DrawFloatField(stats.GetType().GetField("AccelerationCurve"), stats);
            stats.AddedGravity = DrawFloatField(stats.GetType().GetField("AddedGravity"), stats);
            stats.Braking = DrawFloatField(stats.GetType().GetField("Braking"), stats);
            stats.ReverseAcceleration = DrawFloatField(stats.GetType().GetField("ReverseAcceleration"), stats);
            stats.ReverseSpeed = DrawFloatField(stats.GetType().GetField("ReverseSpeed"), stats);
            stats.Steer = DrawFloatField(stats.GetType().GetField("Steer"), stats);
            stats.CoastingDrag = DrawFloatField(stats.GetType().GetField("CoastingDrag"), stats);
            stats.Grip = DrawFloatField(stats.GetType().GetField("Grip"), stats);
            stats.Suspension = DrawFloatField(stats.GetType().GetField("Suspension"), stats);
        }

        private void SetDefaultStats()
        {
            stats = new ArcadeKart.Stats
            {
                TopSpeed = 10f,
                Acceleration = 5f,
                AccelerationCurve = 4f,
                Braking = 10f,
                ReverseAcceleration = 5f,
                ReverseSpeed = 5f,
                Steer = 5f,
                CoastingDrag = 4f,
                Grip = .95f,
                AddedGravity = 1f,
                Suspension = .2f
            };
        }

        private float DrawFloatField(FieldInfo field, object obj)
        {
            RangeAttribute range = field.GetCustomAttribute<RangeAttribute>();

            if (range != null)
                return EditorGUILayout.Slider(field.Name, (float)field.GetValue(obj), range.min, range.max);

            return EditorGUILayout.FloatField(field.Name, (float)field.GetValue(obj));
        }

        private void ShowKartSelector()
        {
            EditorGUILayout.BeginHorizontal();
            kart = EditorGUILayout.ObjectField("Kart", kart, typeof(ArcadeKart), false) as ArcadeKart;
            string kartSelectLabel = kart == null ? "Use selected kart" : "Replace with selected kart";

            if (Selection.activeGameObject?.GetComponent<ArcadeKart>() != null && GUILayout.Button(kartSelectLabel, GUILayout.MaxWidth(160)))
            {
                kart = Selection.activeGameObject.GetComponent<ArcadeKart>();
                stats = kart.baseStats;
            }

            EditorGUILayout.EndHorizontal();

            if (kart == null)
                EditorGUILayout.HelpBox("Select a kart on the project view to edit", MessageType.Info);
        }
    }
}
