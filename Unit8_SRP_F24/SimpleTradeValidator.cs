
using System;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class SimpleTradeValidator : ITradeValidator
{
    private readonly ILogger logger;
    public SimpleTradeValidator(ILogger logger)
    {
        this.logger = logger;
    }
    /// <summary>
    /// Checks the formate on a single line in the trade file.
    /// </summary>
    /// <param name="fields"> The string must be split into three components before calling </param>
    /// <param name="currentLine"> This is the current line number in the file, used to report errors</param>
    /// <returns> true if all the checks pass </returns>
    public bool ValidateTradeData(String[] fields, int currentLine)
    {
        if (fields.Length != 3)
        {
            logger.LogMessage("WARN: Line {0} malformed. Only {1} field(s) found.", currentLine, fields.Length);
            return false;
        }

        if (fields[0].Length != 6 || !fields[0].All(char.IsLetter))
        {
            logger.LogMessage("WARN: Trade currencies on line {0} malformed: '{1}'", currentLine, fields[0]);
            return false;
        }

        int tradeAmount;
        if (!int.TryParse(fields[1], out tradeAmount))
        {
            logger.LogMessage("WARN: Trade amount on line {0} not a valid integer: '{1}'", currentLine, fields[1]);
            return false;
        }

        if (tradeAmount < 1000 || tradeAmount > 1000000)
        {
            logger.LogMessage("WARN: Trade amount on line {0} outside allowed range: '{1}'", currentLine, fields[1]);
            return false;
        }

        decimal tradePrice;
        if (!decimal.TryParse(fields[2], out tradePrice))
        {
            logger.LogMessage("WARN: Trade price on line {0} not a valid decimal: '{1}'", currentLine, fields[2]);
            return false;
        }

        if (tradePrice <= 0)
        {
            logger.LogMessage("WARN: Trade price on line {0} must be greater than zero: '{1}'", currentLine, fields[2]);
            return false;
        }

        return true;
    }
}
