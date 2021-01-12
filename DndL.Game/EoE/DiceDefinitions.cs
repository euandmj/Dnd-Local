using DndL.Core.Exceptions;
using DndL.Core.Extensions;
using DndL.Game.Dice;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace DndL.Game.EoE
{
    public static class DiceMediaProvider
    {
        private static readonly string[] resNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        private static readonly ResourceManager resMgr = new("DndL.Game.Properties.EoE", Assembly.GetExecutingAssembly());

        public static Bitmap GetDiceImage(string res)
        {
            if (resNames.Contains(res))
                throw new ResourceNotFoundException(res);

            return (Bitmap)resMgr.GetObject(res);
        }

        public static DieValueAttribute GetDieValue(this Enum enu)
        {
            var val = enu.GetAttributeFromEnumField<DieValueAttribute>();
            return val;
        }
    }


    public class DiceDefinitions
    {
        public enum Boost
        {
            Blank,
            Blank2,
            [DieValue(FriendlyName = "Success", ImageResourceName = "Success", BackColor = "Blue")]
            Success,
            Advantage,
            AdvantageDouble,
            AdvantageSuccess,
        }

        public enum Ability
        {
            Blank,
            Success,
            Success2,
            Advantage,
            Advantage2,
            AdvantageSuccess,
            AdvantageDouble,
            SuccessDouble
        }

        public enum Proficiency
        {
            Blank,
            Triumph,
            Success,
            Success1,
            Advantage,
            AdvantageSuccess,
            AdvantageSuccess2,
            AdvantageSuccess3,
            SuccessDouble,
            SuccessDouble2,
            AdvantageDouble,
            AdvantageDouble2
        }

        public enum Setback
        {
            Blank,
            Blank2,
            Failure,
            Failure2,
            Threat,
            Threat2
        }

        public enum Difficulty
        {
            Blank,
            Failure,
            Threat,
            Threat2,
            Threat3,
            FailureDouble,
            ThreatFailure,
            ThreatDouble
        }

        public enum Challenge
        {
            Blank,
            Despair,
            Failure,
            Failure2,
            Threat,
            Threat2,
            FailureDouble,
            FailureDouble2,
            ThreatDouble,
            ThreatDouble2,
            ThreatFailure,
            ThreatFailure2
        }

        public enum Force
        {
            Light,
            Light2,
            LightDouble,
            LightDouble2,
            LightDouble3,
            Dark,
            Dark2,
            Dark3,
            Dark4,
            Dark5,
            Dark6,
            DarkDouble
        }
    }
}
