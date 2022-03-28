using System.Collections.Generic;
using UnityEngine;

namespace Connections
{
    public static class FormDataFactory
    {
        public static WWWForm Create(Dictionary<string, string> fields)
        {
            WWWForm form = new WWWForm();
            foreach (KeyValuePair<string, string> field in fields)
            {
                form.AddField(field.Key, field.Value);
            }
            return form;
        }
    }
}