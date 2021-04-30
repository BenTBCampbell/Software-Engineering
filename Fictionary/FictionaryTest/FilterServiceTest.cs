using Fictionary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FictionaryTest
{
    [TestClass]
    public class FilterServiceTest
    {
        [TestMethod]
        public void NormalBadWordsAreNotClean()
        {
            List<string> dirtyMessages = new List<string> 
            { 
                "You should never say asshole",
                "You should never say bitch",
                "You should never say bullshit",
                "You should never say cock",
                "You should never say damn",
                "You should never say effing",
                "You should never say fuck",
                "You should never say shit",
                "You should never say nigga",
                "You should never say nigger",
                "You should never say prick",
                "You should never say slut"
            };

            bool dirtyMessageIsFoundClean = false;

            foreach (string message in dirtyMessages)
            {
                if (FilterService.IsClean(message))
                {
                    dirtyMessageIsFoundClean = true;
                    break;
                }
            }

            Assert.IsFalse(dirtyMessageIsFoundClean);
        }

        [TestMethod]
        public void BadWordsWithLeetAreNotClean()
        {
            List<string> dirtyMessages = new List<string>
            {
                "You should never say 455h0l3",
                "You should never say 81tch",
                "You should never say bull5h1t",
                "You should never say c0ck",
                "You should never say d4mn"
            };

            bool dirtyMessageIsFoundClean = false;

            foreach (string message in dirtyMessages)
            {
                if (FilterService.IsClean(message))
                {
                    dirtyMessageIsFoundClean = true;
                    break;
                }
            }

            Assert.IsFalse(dirtyMessageIsFoundClean);
        }

        [TestMethod]
        public void BadWordsWithCapitalsAreNotClean()
        {
            List<string> dirtyMessages = new List<string>
            {
                "You should never say Asshole",
                "You should never say bITch",
                "You should never say bULLshit",
                "You should never say cOck",
                "You should never say damN",
                "You should never say eFfiNg",
                "You should never say fuCk"
            };

            bool dirtyMessageIsFoundClean = false;

            foreach (string message in dirtyMessages)
            {
                if (FilterService.IsClean(message))
                {
                    dirtyMessageIsFoundClean = true;
                    break;
                }
            }

            Assert.IsFalse(dirtyMessageIsFoundClean);
        }

        [TestMethod]
        public void BadWordsWithSpacesAreNotClean()
        {
            List<string> dirtyMessages = new List<string>
            {
                "You should never say as shole",
                "You should never say bi t  ch",
                "You should never say bull sh it",
                "You should never say coc k",
                "You should never say d amn",
                "You should never say eff ing",
                "You should never say fu ck",
                "You should never say s hit",
                "You should never say nig  ga",
                "You should never say ni gger",
                "You should never say pri ck",
                "You should never say sl ut"
            };

            bool dirtyMessageIsFoundClean = false;

            foreach (string message in dirtyMessages)
            {
                if (FilterService.IsClean(message))
                {
                    dirtyMessageIsFoundClean = true;
                    break;
                }
            }

            Assert.IsFalse(dirtyMessageIsFoundClean);
        }
        
        [TestMethod]
        public void BadWordsWithNoSpacesAreNotClean()
        {
            List<string> dirtyMessages = new List<string>
            {
                "You should never sayassholebecause it's bad.",
                "You should never saybitchwhen you want to.",
                "You should never saybullshitsince that's mean.",
            };

            bool dirtyMessageIsFoundClean = false;

            foreach (string message in dirtyMessages)
            {
                if (FilterService.IsClean(message))
                {
                    dirtyMessageIsFoundClean = true;
                    break;
                }
            }

            Assert.IsFalse(dirtyMessageIsFoundClean);
        }

        [TestMethod]
        public void CleanMessagesAreClean()
        {
            List<string> dirtyMessages = new List<string>
            {
                "This sentence is clean.",
                //"We deciced not to add hell to out blacklist because people" +
                    "can use that in a sentence appropriately",
                "Some other possible bad words we didn't include are and darn.",
            };

            bool cleanMessageIsFoundDirty = false;

            foreach (string message in dirtyMessages)
            {
                if (!FilterService.IsClean(message))
                {
                    cleanMessageIsFoundDirty = true;
                    break;
                }
            }

            Assert.IsFalse(cleanMessageIsFoundDirty);
        }
    }
}
