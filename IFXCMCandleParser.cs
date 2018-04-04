using System.Collections.Generic;

namespace FXCMRestAPIExample
{
    public interface IFXCMCandleParser
    {
        List<FXCMCandle> ParseCandles(FXCMResponse fxcmResponse);
    }
}