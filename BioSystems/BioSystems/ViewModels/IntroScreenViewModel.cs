using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioSystems.Models;

namespace BioSystems.ViewModels
{
    public class IntroScreenViewModel {
        #region Properties
        public int Index = 0;
        public ObservableCollection<IntroScreen> IntroScreens {  get; set; } = new ObservableCollection<IntroScreen>();
        #endregion
        public IntroScreenViewModel() {
            IntroScreens.Add(new IntroScreen{
                Description = "Somos uma empresa comprometida com a inovação, transformando a maneira como as pessoas realizam descarte de materiais.",
                Title = "Bem vindo ao Bio Sistemis",
                Image = "biosistemis"
            });

            IntroScreens.Add(new IntroScreen {
                Description = "Nosso objetivo é oferecer soluções mais eficientes e sustentáveis, promovendo um futuro mais verde para todos.\n" +
                    "Com o Bio Sistemis você vai contribuir para um planeta mais saudável enquanto desfruta de um processo simples, ágil e consciente. Estamos juntos nessa missão de fazer a diferença!",
                Title = "",
                Image = "biosistemis"
            });

            IntroScreens.Add(new IntroScreen {
                Description = "",
                Title = "Juntos por um futuro sustentável",
                Image = "biosistemis"
            });
        }

        public void NextPosition() {
            Index++;
        }

        public void JumpPosition() {
            Index = 3;
        }
    }
}
