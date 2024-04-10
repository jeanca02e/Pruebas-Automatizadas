using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Drawing;
using System.Drawing.Imaging;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {


            IWebDriver driver = new ChromeDriver();


            try
            {
                //Prueba de búsqueda
                pruebaBusqueda(driver);

                //Prueba de navegación
                pruebaNavegacion(driver);

                pruebaAcercaDe(driver);

                pruebaCambiarApariencia(driver);

                pruebaDoodles(driver);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
            finally
            {
                // Cerrar el navegador al finalizar la prueba
                System.Threading.Thread.Sleep(10000);
                 driver.Quit();
            }
        }

        static void pruebaBusqueda(IWebDriver driver)
        {
            string imagesFolderPath = @"C:\Users\Jean_K\source\repos\Selenium test\Selenium test\imagenesPrimera";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };


            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Maximize();
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");


            string[] searchTerms = { "Youtube", "Wikipedia", "123456", "Eclipse solar 2024" };
            foreach (string term in searchTerms)
            {
                IWebElement searchBox = driver.FindElement(By.Name("q"));

                // Limpiar input antes de comenzar la búsqueda
                searchBox.Clear();

                searchBox.SendKeys(term);

                // Enviar la búsqueda presionando Enter
                searchBox.SendKeys(Keys.Enter);

                // Esperar a que se carguen los resultados
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.TitleContains(term));
                takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
              



                // Revisar que los datos sean correctos
                string pageTitle = driver.Title;
                if (pageTitle.Contains(term))
                {
                    Console.WriteLine($"La búsqueda '{term}' fue exitosa.");
                }
                else
                {
                    Console.WriteLine($"La búsqueda '{term}' falló.");
                }
            }
        }

        static void pruebaNavegacion(IWebDriver driver)

        {
            Console.WriteLine("si llegó");
            string imagesFolderPath = @"C:\Users\Jean_K\source\repos\Selenium test\Selenium test\imagenesSegunda";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };

            driver.Navigate().GoToUrl("https://www.google.com/");
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            IWebElement botonPaneles = driver.FindElement(By.CssSelector("#gbwa > div > a"));
            botonPaneles.Click();
            //espera 3s para mostrar los diferentes servicios de google
            System.Threading.Thread.Sleep(3000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            Console.WriteLine("leggp hasta aqui 2");

            //ir a gmail
            IWebElement gmailLink = driver.FindElement(By.LinkText("Gmail"));
            gmailLink.Click();
            //3s para mostrar la pagina y luego volver atras
            System.Threading.Thread.Sleep(3000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(5000);
            


            botonPaneles = driver.FindElement(By.CssSelector("#gbwa > div > a"));
            botonPaneles.Click();
            System.Threading.Thread.Sleep(5000);

            driver.Navigate().GoToUrl("https://www.google.com/maps");
            System.Threading.Thread.Sleep(5000);
            

        }

        static void pruebaAcercaDe(IWebDriver driver)
        {
            string imagesFolderPath = @"C:\Users\Jean_K\source\repos\Selenium test\Selenium test\imagenesTercera";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };



            driver.Navigate().GoToUrl("https://www.google.com/");
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            IWebElement buton = driver.FindElement(By.CssSelector("a[href='https://about.google/?utm_source=google-DO&utm_medium=referral&utm_campaign=hp-footer&fg=1']"));
            buton.Click();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");
            IWebElement videoOverlay = driver.FindElement(By.CssSelector(".modules-lib__video__overlay--crossfade"));

            // Haz clic en el elemento <div> para reproducir el video
            videoOverlay.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 300)");
            System.Threading.Thread.Sleep(15000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");

        }


        static void pruebaCambiarApariencia(IWebDriver driver)
        {
            string imagesFolderPath = @"C:\Users\Jean_K\source\repos\Selenium test\Selenium test\imagenesCuarta";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };



            driver.Navigate().GoToUrl("https://www.google.com/");
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla
            IWebElement preferenciasElement = driver.FindElement(By.XPath("//div[@class='ayzqOc pHiOh' and text()='Preferencias']"));

            preferenciasElement.Click();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla

            IWebElement boton = driver.FindElement(By.CssSelector("#YUIDDb > div > div:nth-child(1)"));
            boton.Click();
            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla

            preferenciasElement = driver.FindElement(By.XPath("//div[@class='ayzqOc pHiOh' and text()='Preferencias']"));
            preferenciasElement.Click();
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla

            IWebElement elemento = driver.FindElement(By.CssSelector("#YUIDDb > div > div:nth-child(1)"));
            elemento.Click();

            System.Threading.Thread.Sleep(5000);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla
        }

        static void pruebaDoodles(IWebDriver driver)
        {
            string imagesFolderPath = @"C:\Users\Jean_K\source\repos\Selenium test\Selenium test\imagenesQuinta";

            // Verificar si la carpeta existe si no crearla
            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            Action<string> takeScreenshot = (fileName) =>
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string filePath = Path.Combine(imagesFolderPath, fileName);
                screenshot.SaveAsFile(filePath);
            };


            driver.Navigate().GoToUrl("https://www.google.com/");
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla
            IWebElement elemento = driver.FindElement(By.CssSelector("body > div.L3eUgb > div.o3j99.ikrT4e.om7nvf > form > div:nth-child(1) > div.A8SBwf > div.FPdoLc.lJ9FBc > center > input.RNmpXc"));
            elemento.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla
            driver.Navigate().GoToUrl("https://doodles.google/search/");
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla

            IWebElement campoEntrada = driver.FindElement(By.ClassName("search-doodle__box-input"));

            // Limpiar el campo de entrada para asegurarse de que esté vacío
            campoEntrada.Clear();


            campoEntrada.SendKeys("republica dominicana");
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla
            System.Threading.Thread.Sleep(5000);
            IWebElement boton = driver.FindElement(By.CssSelector("#content > div > div > div.search-doodle__box > form > div.search-doodle__box-wrapper > div.search-doodle__box-button_wrapper > button.search-doodle__box-button_search.active"));
            boton.Click();
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla
            System.Threading.Thread.Sleep(5000);
            
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 300)");
            takeScreenshot($"screenshot_{DateTime.Now:yyyyMMddHHmmss}.png");//captura de pantalla
        }

    }
}
