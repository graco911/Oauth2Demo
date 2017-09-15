using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Oauth2Demo
{
    public class Services
    {
        public async Task<NeurioUser> GetUserDataAsync()
        {
            NeurioUser detailinfo = new NeurioUser();
            var url = string.Format("https://api.neur.io/v1/users/current");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("Authorization:Bearer", "AIOO-2nhz_XRntjYoXAL1GFyU7eVgP4G1oJsxs8MEWPhDBPDxEjJk1H11erLKeYGxdhvZMm_8D6Cz8jAfJwTaMt5DlIkjvxjGlI0AFRYpbFj7gYYQdhVV_LtabIj4fK2BzVjE3IoOBZGmUh36F9rOHMhuUqyouhboSWWdWKW83FgtsXx3vzwjSPhaxKAf_a97_B1cxnB4hVz5vJDqfy4uQ7C7avXeFfn2LuerwzVnBPk6SGELCXhQM7bk-XchNOKehVNHqCcV0aI");
                    client.DefaultRequestHeaders.Add("Authorization", " Bearer AIOO-2mAeXALcpEzqaLHfF24to06S3AMA24GhNDofVpjH83OcjjWMriITvPSCpZYDWLR5Dmu7E0cVD2JCXvAlycb8VDKU6P4a-vuPiUC9VQHRmVH7KM50SyR6dubfUe7fgAHj4m1NrF1wD3h24p5uaQK04kevKjXGMR_OShpWaHemEk1IbLjh6AFYq5tGnqVqQh-atMWc-HDuQRPggrbZE2epyB_zLC_jQYoOemLWQ0RCHJUTQzX3Y4r5rLkqs1eH1wIf6pmEN7_");
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        var tem = res.Content.ReadAsStringAsync().Result;
                        if (tem.Length > 0)
                        {
                            JsonConvert.PopulateObject(tem, detailinfo);
                        }
                    }
                }
            }
            catch (Exception e) { }
            return detailinfo;
        }

        public async Task<SensorData> GetSensorDataAsync()
        {
            SensorData detailinfo = new SensorData();
            var url = string.Format("https://api.neur.io/v1/samples/live/last?sensorId=0x0000C47F510191A5");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("Authorization:Bearer", "AIOO-2nhz_XRntjYoXAL1GFyU7eVgP4G1oJsxs8MEWPhDBPDxEjJk1H11erLKeYGxdhvZMm_8D6Cz8jAfJwTaMt5DlIkjvxjGlI0AFRYpbFj7gYYQdhVV_LtabIj4fK2BzVjE3IoOBZGmUh36F9rOHMhuUqyouhboSWWdWKW83FgtsXx3vzwjSPhaxKAf_a97_B1cxnB4hVz5vJDqfy4uQ7C7avXeFfn2LuerwzVnBPk6SGELCXhQM7bk-XchNOKehVNHqCcV0aI");
                    client.DefaultRequestHeaders.Add("Authorization", " Bearer AIOO-2mAeXALcpEzqaLHfF24to06S3AMA24GhNDofVpjH83OcjjWMriITvPSCpZYDWLR5Dmu7E0cVD2JCXvAlycb8VDKU6P4a-vuPiUC9VQHRmVH7KM50SyR6dubfUe7fgAHj4m1NrF1wD3h24p5uaQK04kevKjXGMR_OShpWaHemEk1IbLjh6AFYq5tGnqVqQh-atMWc-HDuQRPggrbZE2epyB_zLC_jQYoOemLWQ0RCHJUTQzX3Y4r5rLkqs1eH1wIf6pmEN7_");
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        var tem = res.Content.ReadAsStringAsync().Result;
                        if (tem.Length > 0)
                        {
                            JsonConvert.PopulateObject(tem, detailinfo);
                        }
                    }
                }
            }
            catch (Exception e) { }
            return detailinfo;
        }
    }
}