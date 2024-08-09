using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicalSide
{
    public interface IContext
    {
        bool Turn{get; }
        
        CustomList<ICard> Deck{get; }
        CustomList<ICard> OtherDeck{get; }
        CustomList<ICard> DeckOfPlayer(IPlayer player);
        
        
        CustomList<ICard> GraveYard{get; }
        CustomList<ICard> OtherGraveYard{get; }
        
        CustomList<ICard> GraveYardOfPlayer(IPlayer player);
        
        CustomList<ICard> Field{get; }
        CustomList<ICard> OtherField{get; }
        CustomList<ICard> FieldOfPlayer(IPlayer player);
        
        
        CustomList<ICard> Hand{get; }
        CustomList<ICard> OtherHand{get; }


        CustomList<ICard> HandOfPlayer(IPlayer player);
        CustomList<ICard> Board{get; }
        IPlayer TriggerPlayer{get; }
    }


    public abstract class ICard
    {
        public abstract string Name{get; set;}
        public abstract string Type{get; set;}
        public abstract int Power{get; set;}
        public abstract string Range{get; set;}
        public abstract IPlayer Owner{get; set;}
        public abstract string Faction{get; set;}
        public abstract List<IEffect> Effects{get; set;}

        public void Execute(IContext context)
        {
            foreach(IEffect effect in Effects)
            {
                effect.Execute(context);
            }
        }
        
    }
    public class MyCard: ICard
    {
        public override string Name{get; set;}
        public override string Type{get; set;}
        public override int Power{get; set;}
        public override string Range{get; set;}
        public override IPlayer Owner{get; set;}
        public override string Faction{get; set;}
        public override List<IEffect> Effects{get; set;}
        public override string ToString()
        {
            string result= "";
            result += "Name: " + Name + "\n";
            result += "Type: " + Type + "\n";
            result += "Power: " + Power + "\n";
            result += "Range: " + Range + "\n";
            result += "Owner: " + Owner + "\n";
            result += "Faction: " + Faction + "\n";
            result += "Efectos: \n";
            int conta = 1;
            foreach(IEffect effect in Effects)
            {
                Console.WriteLine($"{conta++}- "+ effect);
            }
            return result;
        }
    }
    public interface IPlayer
    {
        bool Turn{get; set;}
    }
    
    public interface IEffect
    {
        EffectDeclarationExpr effect{get; set;}
        List<IdentifierExpression> Params{get; set;}
        SelectorExpression Selector{get; set;}

        void Execute(IContext context)
        {
            CustomList<ICard> targets= new(null,null);
            if(Selector!= null)
            targets= Selector.Execute(context);
            effect.Execute(context, targets, Params);
        }
    }
    public class MyEffect: IEffect
    {
        public MyEffect(EffectDeclarationExpr eff, SelectorExpression Sel, List<IdentifierExpression> Par)
        {
            effect = eff;
            Selector = Sel;
            Params= Par;
        }
        public List<IdentifierExpression> Params{get; set;}

        public EffectDeclarationExpr effect{get; set;}

        public SelectorExpression Selector{get; set;}
        public override string ToString()
        {
            string s= "Efecto: " + (string)effect.Name.Value+ "\n";
            foreach(IdentifierExpression identifier in Params)
            {
                s+= identifier.ValueAsToken.Value+ "\n";
            }
            return s;
        }
    }

}