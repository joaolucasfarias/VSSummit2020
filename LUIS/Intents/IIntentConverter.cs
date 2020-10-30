using System;
using System.Collections.Generic;
using System.Text;

namespace LUIS.Intents
{
    internal interface IIntentConverter
    {
        IntentResult Convert();
    }
}
