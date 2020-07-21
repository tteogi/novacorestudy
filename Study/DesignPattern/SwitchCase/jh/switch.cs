using System;
using System.Collections.Generic;
using System.Text;

namespace Builder_nong
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
        public Challenge[] ChallengeArray { get; set; }

        public void InitChallenge()
        {
            ChallengeArray = new Challenge[3];

            StageChallengeType[] Type;
            Type = new StageChallengeType[3];
            Type[0] = StageChallengeType.MaxTurn;
            Type[1] = StageChallengeType.NoHealHOT;
            Type[2] = StageChallengeType.CountUseItem;

            for (int i = 0; i < 3; i++)
            {
                switch (Type[i])
                {
                    case StageChallengeType.Clear:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.MaxTurn:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.GreaterThan).SetValue(1).Build();
                        break;
                    case StageChallengeType.NoHealHOT:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.CountUseItem:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.LessThan).SetValue(1).Build();
                        break;
                    case StageChallengeType.CountDeath:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.JobFixed:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.JobBanned:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.GradeFixed:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.GradeBanned:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.CountMember:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.AttributeFixed:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    case StageChallengeType.AttributeBanned:
                        ChallengeArray[i] = new Challenge.ChallengeBuilder().SetCalculate(eOperation.Equal).SetValue(1).Build();
                        break;
                    default:
                        Console.WriteLine("Error Challenge Type");
                        break;
                }
            }
        }

        public bool ClearChallenge(int i)
        {
            return ChallengeArray[i].CheckSuccess(1);
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
            switch (Operation)
            {
                case eOperation.LessThan:
                    if (Value > value)
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
                return new Challenge(Value, Operation);
            }
        }
    }
}