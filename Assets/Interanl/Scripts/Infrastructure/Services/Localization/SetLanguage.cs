﻿// **************************************************************** //
//
//   Copyright (c) Vanchegs and RimuruDev. All rights reserved.
//   Project: Primitime 2023
//   Contact: 
//         Vanchegs
//           - GitHub:   https://github.com/Vanchegs
//           - Gmail:    manshin9300@gmail.com
//         RimuruDev
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//
// **************************************************************** //

using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Vanchegs.Interanl.Scripts.Infrastructure.Services.Localization
{
    [DisallowMultipleComponent]
    public sealed class SetLanguage : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text Text { get; private set; }
        [SerializeField] private List<LanguageUnit> languageUnits;

        public void UpdateLanguage(Language language)
        {
            Text.text = languageUnits.FirstOrDefault(l => l.language == language)?.text;

            // foreach (var languageUnit in languageUnits)
            // {
            //     if (languageUnit.language == language)
            //         Text.text = languageUnit.text;
            // }
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate()
        {
            if (Text == null)
                Text = GetComponent<TMP_Text>();
        }

        [Serializable]
        public sealed class LanguageUnit
        {
            public Language language;
            public string text;
        }
    }
}