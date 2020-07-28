using System;
using System.Collections.Generic;
using System.Text;

namespace Switch
{
    public enum StageChallengeType
    {
        Clear = 1,
        MaxTurn = 2,
        CountDeath = 3,
        CountUseItem = 4,
        CountMember = 5,
        NoHealHOT = 6,
        JobFixed = 7,
        JobBanned = 8,
        AttributeFixed = 9,
        AttributeBanned = 10,
        GradeFixed = 11,
        GradeBanned = 12,
    }

    public enum eOperation
    {
        Equal = 1,
        LessThan = 2,
        GreaterThan = 3,
    }
    public class ChallengeProcess
    {
        public List<Challenge> ChallengeList { get; set; }

        public ChallengeProcess()
        {
            ChallengeList = new List<Challenge>();
        }

        public void InsertChallenge(StageChallengeType eType)
        {
            Challenge challenge = null;

            switch (eType)
            {
                case StageChallengeType.Clear:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.MaxTurn:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.GreaterThan).SetValue(1).Build();
                    break;
                case StageChallengeType.NoHealHOT:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.CountUseItem:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.LessThan).SetValue(1).Build();
                    break;
                case StageChallengeType.CountDeath:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.JobFixed:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.JobBanned:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.GradeFixed:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.GradeBanned:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.CountMember:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.AttributeFixed:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                case StageChallengeType.AttributeBanned:
                    challenge = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                    break;
                default:
                    Console.WriteLine("Error Challenge Type");
                    break;
            }
            ChallengeList.Add( challenge );
        }
        
        public bool ClearChallenge(int i)
        {
            if (ChallengeList.Count > i)
                return ChallengeList[i].CheckSuccess(1);
            else
                return false;
        }
    }

    public class Challenge
    {
        public Challenge(int value, eOperation operation)
        {
            Value = value;
            Operation = operation;
        }
        public int Value { get; }
        public eOperation Operation { get; }
        public bool CheckSuccess(int value)
        {
            switch(Operation)
            {
                case eOperation.LessThan:
                    if(Value > value)
                    {
                        return true;
                    }
                    break;
                case eOperation.GreaterThan:
                    if (Value < value)
                    {
                        return true;
                    }
                    break;
                case eOperation.Equal:
                    if (Value == value)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public class ChallengeBuilder
        {
            private int Value { get; set; }
            private eOperation Operation { get; set; }
            public ChallengeBuilder()
            {

            }

            public ChallengeBuilder SetValue(int value)
            {
                Value = value;
                return this;
            }

            public ChallengeBuilder SetCalculate(eOperation operation)
            {
                Operation = operation;
                return this;
            }

            public Challenge Build()
            {
                return new Challenge( Value, Operation);
            }
        }
    }
}
