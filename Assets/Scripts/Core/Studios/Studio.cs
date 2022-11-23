using System;
using System.Collections.Generic;
using System.Linq;
using Core.Wallets;
using SameOldStory.Core.Data;
using SameOldStory.Core.Buffs;
using UnityEngine;
using Font = SameOldStory.Core.Data.Font;

namespace SameOldStory.Core.Studios {
    
    public class Studio {

        private static Studio current;
        
        public static event Action onStudioChanged;

        public static Studio Current {
            get => current;
            private set {
                current = value;
                onStudioChanged?.Invoke();
            }
        }

        private Genre[] genres;
        private Tone[] colors;
        private Font[] fonts;
        private BuffManager buffManager;

        public IEnumerable<Genre> AvailableGenres => genres.Where(g => g.StartAvailable).ToArray();
        public IEnumerable<Tone> AvailableColors => colors;
        public IEnumerable<Font> AvailableFonts => fonts;
        public Wallet Wallet { get; private set; }

        public static void InitializeNewStudio() {
            Current = new Studio {
                genres = Resources.LoadAll("Genres", typeof(Genre)).Cast<Genre>().ToArray(),
                colors = Resources.LoadAll("Colors", typeof(Tone)).Cast<Tone>().ToArray(),
                fonts = Resources.LoadAll("Fonts", typeof(Font)).Cast<Font>().ToArray(),
                buffManager = new BuffManager(),
                Wallet = new Wallet(100)
            };
        }

        public Genre GetGenreWithName(string genreName) {
            return genres.FirstOrDefault(g => g.name == genreName);
        }

        public void ApplyBuff(Buff buff) => buffManager.ApplyBuff(buff);

    }
    
}