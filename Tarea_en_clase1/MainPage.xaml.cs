namespace Tarea_en_clase1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            pickerIdentificacion.SelectedIndex = 0; // Cédula por defecto
        }

        private void OnIdentificacionChanged(object? sender, EventArgs e)
        {
            // Ajusta la longitud máxima según el tipo de documento
            entryNumero.MaxLength = pickerIdentificacion.SelectedItem?.ToString() switch
            {
                "Cédula" => 10,
                "RUC" => 13,
                _ => 20
            };
            entryNumero.Text = string.Empty;
        }

        private async void OnEnviarClicked(object? sender, EventArgs e)
        {
            if (pickerIdentificacion.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(entryNumero.Text) ||
                string.IsNullOrWhiteSpace(entryPaterno.Text) ||
                string.IsNullOrWhiteSpace(entryNombres.Text) ||
                pickerCarrera.SelectedIndex < 0 ||
                pickerModalidad.SelectedIndex < 0 ||
                pickerCampus.SelectedIndex < 0)
            {
                await DisplayAlert("Error", "Complete todos los campos obligatorios.", "OK");
                return;
            }

            if (entryCorreo.Text != entryConfirmarCorreo.Text)
            {
                await DisplayAlert("Error", "Los correos no coinciden.", "OK");
                return;
            }

            string resumen =
                $"{pickerIdentificacion.SelectedItem}: {entryNumero.Text}\n" +
                $"Carrera: {pickerCarrera.SelectedItem}\n" +
                $"Modalidad: {pickerModalidad.SelectedItem}\n" +
                $"Campus: {pickerCampus.SelectedItem}";

            await DisplayAlert("Inscripción enviada", resumen, "OK");
            SemanticScreenReader.Announce("Inscripción enviada");
        }
    }
}