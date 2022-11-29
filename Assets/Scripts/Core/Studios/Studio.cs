using System;
using System.Collections.Generic;
using System.Linq;
using Core.Movies;
using Core.People;
using Core.Roles;
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
        private Role[] roles;

        public IEnumerable<Genre> AvailableGenres => genres.Where(g => g.StartAvailable).ToArray();
        public Tone[] AvailableColors => colors.OrderBy(t => t.Value.r * 3 + t.Value.g + t.Value.b).ToArray();
        public IEnumerable<Font> AvailableFonts => fonts;
        public Role[] AvailableRoles => roles;

        public Wallet Wallet { get; private set; }
        public BuffManager BuffManager { get; private set; }
        public Roster Roster { get; private set; }
        public MovieLibrary MovieLibrary { get; private set; }

        public static void InitializeNewStudio() {
            Current = new Studio {
                genres = Resources.LoadAll("Genres", typeof(Genre)).Cast<Genre>().ToArray(),
                colors = Resources.LoadAll("Colors", typeof(Tone)).Cast<Tone>().ToArray(),
                fonts = Resources.LoadAll("Fonts", typeof(Font)).Cast<Font>().ToArray(),
                roles = Resources.LoadAll("Roles", typeof(Role)).Cast<Role>().ToArray(),
                BuffManager = new BuffManager(),
                Wallet = new Wallet(100),
                Roster = new Roster(3),
                MovieLibrary = new MovieLibrary()
            };
        }

        public Genre GetGenreWithName(string genreName) {
            return genres.FirstOrDefault(g => g.Name == genreName);
        }
        
        public Font GetFontWithName(string fontName) {
            return fonts.FirstOrDefault(f => f.Name == fontName);
        }

        public void ApplyBuff(Buff buff) => BuffManager.ApplyBuff(buff);

    }
    
}