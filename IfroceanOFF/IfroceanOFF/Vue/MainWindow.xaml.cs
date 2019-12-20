using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
using IfroceanOFF.DAL;
using IfroceanOFF.ORM;
using IfroceanOFF.Ctrl;
using System.Globalization;
using System.Threading;

namespace IfroceanOFF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedPersonneId;
        int selectedEtudeId;
        int selectedPlageId;
        int selectedCommuneId;
        int selectedZoneId;
        int selectedComptageId;

        PersonneViewModel myDataObjectPersonne; // Objet de liaison
        EtudeViewModel myDataObjectEtude; // Objet de liaison
        PlageViewModel myDataObjectPlage; // Objet de liaison
        CommuneViewModel myDataObjectCommune; // Objet de liaison
        ZoneViewModel myDataObjectZone; // Objet de liaison
        ComptageViewModel myDataObjectComptage; // Objet de liaison

        ObservableCollection<PersonneViewModel> lp;
        ObservableCollection<EtudeViewModel> le;
        ObservableCollection<EtudeViewModel> lEtudePlage;
        ObservableCollection<CommuneViewModel> lc;
        ObservableCollection<PlageViewModel> lpl;
        ObservableCollection<ZoneViewModel> lz;
        ObservableCollection<ZoneViewModel> lCompteurZone;
        ObservableCollection<ComptageViewModel> lcomp;
        ObservableCollection<CommuneViewModel> lcom;
        ObservableCollection<ZoneViewModel> listeAllZones;

        int compteur = 0;

        public MainWindow()
        {
            InitializeComponent();
            DalConnexion.OpenConnection();

            //CREATION DE LA LISTE A PARTIR DE LA BDD VIA LE FICHIER ORM
            lp = PersonneORM.listePersonnes();
            le = EtudeORM.listeEtudes();
            lc = CommuneORM.listeCommunes();
            lpl = PlageORM.listePlages();
            lz = ZoneORM.listeZones();
            lcomp = ComptageORM.listeComptages();
            lEtudePlage = EtudeORM.requeteEtudePlage();
            lCompteurZone = ZoneORM.compteurZone();
            listeAllZones = ZoneORM.listeAllZones();
            lcom = CommuneORM.listeCommunes();

            //Conversion dateTime
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            //MessageBox.Show()
            //LIEN AVEC la VIEW
            listePersonnes.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            listeEtudes.ItemsSource = le;
            listePlages.ItemsSource = lpl;
            listeZones.ItemsSource = lz;
            listeEtudePlage.ItemsSource = lEtudePlage;
            listeCompteurZone.ItemsSource = lCompteurZone;
            listeCommunes.ItemsSource = lcom;
            listeZonesComplete.ItemsSource = listeAllZones;

            choixEtudes.ItemsSource = le;
            choixEtudesZones.ItemsSource = le;
            choixPlages.ItemsSource = lpl;


            //Récupération titre étude avec requete


            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }
        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObjectPersonne.prenomPersonneProperty = prenom.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObjectPersonne.nomPersonneProperty = nom.Text;
        }
        public void titreChanged(object sender, TextChangedEventArgs e)
        {
            myDataObjectEtude.titreEtudeProperty = titre.Text;
        }

        //UPDATE
        private void updatePersonneButton_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObjectPersonne = new PersonneViewModel();
            myDataObjectPersonne.nomPersonneProperty = nom.Text;
            myDataObjectPersonne.prenomPersonneProperty = prenom.Text;


            PersonneViewModel nouveau = new PersonneViewModel(+1, myDataObjectPersonne.nomPersonneProperty, myDataObjectPersonne.prenomPersonneProperty, myDataObjectPersonne.isAdminPersonneProperty, myDataObjectPersonne.etudePersonneProperty);
            lp.Add(nouveau);
            PersonneORM.updatePersonne(nouveau);
            listePersonnes.Items.Refresh();
            MessageBox.Show("==>update");

        }
        private void updatePlageButton_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObjectPlage = new PlageViewModel();
            myDataObjectPlage.nomPlageProperty = nomPlage.Text;
            myDataObjectPlage.departementPlageProperty = departement.Text;


            PlageViewModel nouveau = new PlageViewModel(+1, myDataObjectPlage.nomPlageProperty, myDataObjectPlage.departementPlageProperty, +1);
            lpl.Add(nouveau);
            PlageORM.updatePlage(nouveau);
            listePlages.Items.Refresh();
            MessageBox.Show("==>update");

        }
        private void updateEtudeButton_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObjectEtude = new EtudeViewModel();
            myDataObjectEtude.titreEtudeProperty = nom.Text;
            myDataObjectEtude.dateCreationEtudeProperty = (DateTime)dateCrea.SelectedDate;
            myDataObjectEtude.dateFinEtudeProperty = (DateTime)dateFin.SelectedDate;

            EtudeViewModel nouveau = new EtudeViewModel(+1, myDataObjectEtude.titreEtudeProperty, myDataObjectEtude.dateFinEtudeProperty, myDataObjectEtude.dateFinEtudeProperty);
            le.Add(nouveau);
            EtudeORM.updateEtude(nouveau);
            listeEtudes.Items.Refresh();
            MessageBox.Show("==>update");

        }
        /*private void updateZoneButton_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObjectZone = new ZoneViewModel();
            myDataObjectZone.pointAProperty = pointA.Text;
            myDataObjectZone.pointBProperty = pointB.Text;
            myDataObjectZone.pointCProperty = pointC.Text;
            myDataObjectZone.pointDProperty = pointD.Text;
            myDataObjectZone.superficieZoneProperty = superficie.Text;


            ZoneViewModel nouveau = new ZoneViewModel(+1, myDataObjectZone.pointAProperty, myDataObjectZone.pointBProperty, myDataObjectZone.pointCProperty, myDataObjectZone.pointDProperty, myDataObjectZone.superficieZoneProperty);
            lz.Add(nouveau);
            ZoneORM.updateZone(nouveau);
            listePersonnes.Items.Refresh();
            MessageBox.Show("==>update");

        }*/

        //FONCTIONS SUPPRIMER AU DOUBLE CLICK
        private void supprimerPersonneButton_Click(object sender, RoutedEventArgs e)
        {
            PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
            lp.Remove(toRemove);
            listePersonnes.Items.Refresh();
            PersonneORM.supprimerPersonne(selectedPersonneId);
        }
        private void supprimerPlageButton_Click(object sender, RoutedEventArgs e)
        {
            PlageViewModel toRemove = (PlageViewModel)listePlages.SelectedItem;
            lpl.Remove(toRemove);
            listePlages.Items.Refresh();
            PlageORM.supprimerPlage(selectedPlageId);
        }
        private void supprimerEtudeButton_Click(object sender, RoutedEventArgs e)
        {
            EtudeViewModel toRemove = (EtudeViewModel)listeEtudes.SelectedItem;
            le.Remove(toRemove);
            listeEtudes.Items.Refresh();
            EtudeORM.supprimerEtude(selectedEtudeId);
        }
        private void supprimerCommuneButton_Click(object sender, RoutedEventArgs e)
        {
            CommuneViewModel toRemove = (CommuneViewModel)listeCommunes.SelectedItem;
            lc.Remove(toRemove);
            listeCommunes.Items.Refresh();
            CommuneORM.supprimerCommune(selectedCommuneId);
        }

        //FONCTIONS LISTES DES DONNEES
        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < lp.Count) && (listePersonnes.SelectedIndex >= 0))
            {
                selectedPersonneId = (lp.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idPersonneProperty;
            }
        }
        private void listeEtudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtudes.SelectedIndex < le.Count) && (listeEtudes.SelectedIndex >= 0))
            {
                selectedEtudeId = (le.ElementAt<EtudeViewModel>(listeEtudes.SelectedIndex)).idEtudeProperty;
            }
        }

        private void listePlages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < lp.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlageId = (lpl.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
            }
        }
        private void listeZones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeZones.SelectedIndex < lp.Count) && (listeZones.SelectedIndex >= 0))
            {
                selectedZoneId = (lz.ElementAt<ZoneViewModel>(listeZones.SelectedIndex)).idZoneProperty;
            }
        }
        private void listeCommunes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeCommunes.SelectedIndex < lc.Count) && (listeCommunes.SelectedIndex >= 0))
            {
                selectedCommuneId = (lc.ElementAt<CommuneViewModel>(listeCommunes.SelectedIndex)).idCommuneProperty;
            }
        }

        //FONCTIONS AJOUTER AU CLICK
        private void ajoutPersonneButton_Click(object sender, RoutedEventArgs e)
        {
            //Sélection isAdmin
            int check;
            if (isAdmin.IsChecked == true)
            {
                check = 0;

            }
            else
            {
                check = 1;
            }

            /*Sélection idEtude
            int selected;
            if (isAdmin.IsChecked == true)
            {
                selected = 0;

            }
            else
            {
                selected = 1;
            }*/
            myDataObjectPersonne = new PersonneViewModel();
            myDataObjectPersonne.nomPersonneProperty = nom.Text;
            myDataObjectPersonne.prenomPersonneProperty = prenom.Text;
            myDataObjectPersonne.etudePersonneProperty = (EtudeViewModel)choixEtudes.SelectedItem;
            myDataObjectPersonne.isAdminPersonneProperty = check;


            PersonneViewModel nouveau = new PersonneViewModel(+1, myDataObjectPersonne.nomPersonneProperty, myDataObjectPersonne.prenomPersonneProperty, myDataObjectPersonne.isAdminPersonneProperty, myDataObjectPersonne.etudePersonneProperty);
            lp.Add(nouveau);
            PersonneORM.insertPersonne(nouveau);
            listePersonnes.Items.Refresh();
            MessageBox.Show("==>insert");
        }

        private void ajoutEtudeButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectEtude = new EtudeViewModel();
            myDataObjectEtude.titreEtudeProperty = titre.Text;
            myDataObjectEtude.dateCreationEtudeProperty = (DateTime)dateCrea.SelectedDate;
            myDataObjectEtude.dateFinEtudeProperty = (DateTime)dateFin.SelectedDate;


            EtudeViewModel nouveau = new EtudeViewModel(+1, myDataObjectEtude.titreEtudeProperty, myDataObjectEtude.dateCreationEtudeProperty, myDataObjectEtude.dateFinEtudeProperty);
            le.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            listeEtudes.Items.Refresh();
            MessageBox.Show("==>insert");
        }
        //            dataPlage.Superficie = Convert.ToInt32(PlageSuperficie_Input.Text);



        private void ajoutPlageButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectPlage = new PlageViewModel();
            myDataObjectPlage.nomPlageProperty = nomPlage.Text;
            myDataObjectPlage.departementPlageProperty = departement.Text;

            PlageViewModel nouveau = new PlageViewModel(+1, myDataObjectPlage.nomPlageProperty, myDataObjectPlage.departementPlageProperty, myDataObjectPlage.communePlageProperty);
            lpl.Add(nouveau);
            PlageORM.insertPlage(nouveau);
            listePlages.Items.Refresh();
            MessageBox.Show("==>insert");
        }
        private void ajoutZoneButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectZone = new ZoneViewModel();
            myDataObjectZone.pointAProperty = pointA.Text;
            myDataObjectZone.pointBProperty = pointB.Text;
            myDataObjectZone.pointCProperty = pointC.Text;
            myDataObjectZone.pointDProperty = pointD.Text;
            myDataObjectZone.PlageProperty = (PlageViewModel)choixPlages.SelectedItem;
            myDataObjectZone.idEtudeProperty = (EtudeViewModel)choixEtudesZones.SelectedItem;

            //myDataObjectZone.superficieZoneProperty = superficie.Text;


            ZoneViewModel nouveau = new ZoneViewModel(+1, myDataObjectZone.pointAProperty, myDataObjectZone.pointBProperty, myDataObjectZone.pointCProperty, myDataObjectZone.pointDProperty, myDataObjectZone.superficieZoneProperty, myDataObjectZone.PlageProperty, myDataObjectZone.idEtudeProperty);
            lz.Add(nouveau);
            ZoneORM.insertZone(nouveau);
            listeZones.Items.Refresh();
            MessageBox.Show("==>insert");
        }
        private void ajoutCommuneButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectCommune = new CommuneViewModel();
            myDataObjectCommune.nomCommuneProperty = nomCommune.Text;

            CommuneViewModel nouveau = new CommuneViewModel(+1, myDataObjectCommune.nomCommuneProperty);
            lc.Add(nouveau);
            CommuneORM.insertCommune(nouveau);
            listeCommunes.Items.Refresh();
            MessageBox.Show("==>insert");
        }


    }
}
