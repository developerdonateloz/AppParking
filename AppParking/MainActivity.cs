using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace AppParking
{
    [Activity(Label = "App Cochera . Gordiiiiita", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/MyTheme")]
    public class MainActivity : Activity
    {
        private List<Registro> ListaRegistros;
        private int iditem = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button btnIngreso = FindViewById<Button>(Resource.Id.btnIngreso);
            Button btnSalida = FindViewById<Button>(Resource.Id.btnSalida);
            Button btnCalcularSaldo = FindViewById<Button>(Resource.Id.btnCalcularSaldo);

            TextView lblMensaje = FindViewById<TextView>(Resource.Id.lblMensaje);

            ListaRegistros = new List<Registro>();

            btnIngreso.Click += delegate { AgregarRegistroIngreso(); };
            btnSalida.Click += delegate { AgregarRegistroSalida(); };
            btnCalcularSaldo.Click += delegate { CalcularSaldo(); };
        }
        private void CalcularSaldo()
        {
            TextView txtPlaca = FindViewById<TextView>(Resource.Id.txtPlaca);
            TextView txtHoraSalida = FindViewById<TextView>(Resource.Id.txtHora);
            TextView lblMensaje = FindViewById<TextView>(Resource.Id.lblMensaje);

            foreach (var item in ListaRegistros)
            {
                if(item.Placa==txtPlaca.Text.Trim() && item.HoraMinutoSalida==string.Empty)
                {
                    lblMensaje.Text = "S/ 15.00";
                }
            }
        }

        private void AgregarRegistroIngreso()
        {
            iditem++;

            TextView txtPlaca = FindViewById<TextView>(Resource.Id.txtPlaca);
            TextView txtDuenio = FindViewById<TextView>(Resource.Id.txtDuenio);
            TextView txtObservaciones = FindViewById<TextView>(Resource.Id.txtObservaciones);
            TextView txtHora = FindViewById<TextView>(Resource.Id.txtHora);
            TextView lblMensaje = FindViewById<TextView>(Resource.Id.lblMensaje);

            if (ExisteIngreso(txtPlaca.Text.Trim()))
            {    
                lblMensaje.Text = "Ingreso ya fue registrado";
                return;
            }

            Registro oregistro = new Registro();
            oregistro.IdRegistro = iditem;
            oregistro.Placa = txtPlaca.Text.Trim();
            oregistro.Duenio = txtDuenio.Text.Trim();
            oregistro.Observaciones = txtObservaciones.Text.Trim();
            oregistro.HoraMinutoIngreso = txtHora.Text.Trim();
            oregistro.HoraMinutoSalida = string.Empty;

            ListaRegistros.Add(oregistro);

            lblMensaje.Text = "Gordita, ingreso ya está registrado, jojolete";

            txtPlaca.Text = string.Empty;
            txtDuenio.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            txtHora.Text = string.Empty;

        }
        private void AgregarRegistroSalida()
        {
            TextView txtPlaca = FindViewById<TextView>(Resource.Id.txtPlaca);
            if (!ExisteIngreso(txtPlaca.Text.Trim()))
            {
                TextView lblMensaje = FindViewById<TextView>(Resource.Id.lblMensaje);
                lblMensaje.Text = "Auto no ha tiene ingreso.";
                return;
            }
            else
            {

            }
        }
        private bool ExisteIngreso(string placa)
        {
            bool retorno = false;

            foreach (var item in ListaRegistros)
            {
                if (item.Placa == placa && item.HoraMinutoSalida==string.Empty)
                    return true;
            }
            return retorno;
        }
    }
    public class Registro
    {
        public int IdRegistro { get; set; }
        public string Placa { get; set; }
        public string Duenio { get; set; }
        public string Observaciones { get; set; }
        public string HoraMinutoIngreso { get; set; }
        public string HoraMinutoSalida { get; set; }
    }
}

