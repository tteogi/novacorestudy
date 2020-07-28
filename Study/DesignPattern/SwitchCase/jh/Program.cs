using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Switch
{
    class Program
    {

        static void Main(string[] args)
        {
            ChallengeProcess challengeProcess = new ChallengeProcess();

            challengeProcess.InsertChallenge(StageChallengeType.MaxTurn);
            challengeProcess.InsertChallenge(StageChallengeType.NoHealHOT);
            challengeProcess.InsertChallenge(StageChallengeType.CountUseItem);

            for (int i = 0; i < 4; i++)
            {
                if(challengeProcess.ClearChallenge(i))
                    Console.WriteLine("Clear");
                else
                    Console.WriteLine("Not Clear");
            }
        }
    }
}
