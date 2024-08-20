﻿using System;
using System.Collections.Generic;
using System.IO;
using LogicalSide;

namespace LogicalSide
{
    public static class Compiler
    {

        public static List<ICard> Compile(string path)
        {
            string filePath = path;
            string text = File.ReadAllText(filePath);
            //Lexer
            Lexer l = new Lexer(text);
            List<Token> tokens = l.Tokenize();
            //Parser
            Parser parser = new(tokens);
            Expression root = parser.Parse();
            //Semantic
            Semantic semantic= new Semantic(root);
            //Evaluate
            List<ICard> cards= (List<ICard>)root.Evaluate(null!,null!);
            return cards;
        }

        public static void PrintExpressionTree(Expression node, int indentLevel = 0)
        {
            node.Print(indentLevel);
            if (node is BinaryOperator binaryNode)
            {
                PrintExpressionTree(binaryNode.Left, indentLevel + 1);
                PrintExpressionTree(binaryNode.Right, indentLevel + 1);
            }
            
            
            else if(node is ActionExpression action)
            {
                PrintExpressionTree(action.Context,indentLevel+1);
                PrintExpressionTree(action.Targets,indentLevel+1);
                PrintExpressionTree(action.Instructions,indentLevel+1);
            }
            
            
            else if(node is UnaryOperator unaryOperator){
            if(unaryOperator.Operand!=null)
            PrintExpressionTree(unaryOperator.Operand, indentLevel + 1);
            }
            
            
            else if (node is Terminal numberNode)
            {
                Console.WriteLine(new string(' ', indentLevel * 4) + $"Value: {numberNode.ValueForPrint}");
            }
            
            
            else if (node is ProgramExpression prognode)
            {
                foreach(Expression exp in prognode.EffectsAndCards)
                {
                    if( exp is EffectDeclarationExpr eff)
                    {
                        PrintExpressionTree(eff, indentLevel + 1);
                    }
                    else if(exp is CardExpression card)
                    {
                        PrintExpressionTree(card, indentLevel + 1);
                    }

                }
            }
            
            
            else if (node is EffectDeclarationExpr effNode)
            {
                if(effNode.Name!= null)
                PrintExpressionTree(effNode.Name, indentLevel + 1);
                if(effNode.Params != null)
                {
                    Console.WriteLine(new string(' ', (indentLevel+1) * 4) + $"Params");
                    foreach(Expression param in effNode.Params)
                    PrintExpressionTree(param, indentLevel + 2);
                }
                if(effNode.Action!= null)
                {
                    PrintExpressionTree(effNode.Action);
                }
            }
            
            
            else if(node is EffectAssignment effassign)
            {
                if(effassign.Effect!= null)
                {
                    foreach(Expression exp in effassign.Effect)
                    {
                        PrintExpressionTree(exp, indentLevel +1);
                    }
                }
                if(effassign.Selector!= null)
                {
                    PrintExpressionTree(effassign.Selector,indentLevel+1);
                }
                if(effassign.PostAction!= null)
                {
                    PrintExpressionTree(effassign.PostAction);
                }
            }
            
            
            else if(node is OnActivationExpression onact)
            {
                foreach(Expression eff in onact.Effects)
                PrintExpressionTree(eff, indentLevel+1);
            }
            
            
            else if (node is CardExpression card)
            {
                if(card.Name!= null)
                PrintExpressionTree(card.Name, indentLevel + 1);
                if(card.Power!= null)
                PrintExpressionTree(card.Power, indentLevel + 1);
                if(card.Type!= null)
                PrintExpressionTree(card.Type, indentLevel + 1);
                if(card.Range != null)
                {
                    Console.WriteLine(new string(' ', (indentLevel+1) * 4) + $"Range");
                    foreach(Expression range in card.Range)
                    PrintExpressionTree(range, indentLevel + 2);
                }
                if(card.OnActivation!=null)
                {
                    PrintExpressionTree(card.OnActivation, indentLevel + 1);
                }
            }
            
            
            else if(node is InstructionBlock instructionBlock)
            {
                foreach(Expression exp in instructionBlock.Instructions)
                {
                    PrintExpressionTree(exp, indentLevel + 1);
                }
            }
            
            
            else if(node is ForExpression forexp)
            {
                PrintExpressionTree(forexp.Variable, indentLevel+1);
                PrintExpressionTree(forexp.Collection,indentLevel +1);
                PrintExpressionTree(forexp.Instructions,indentLevel +1);
            }
            
            
            else if(node is WhileExpression whilexp)
            {
                PrintExpressionTree(whilexp.Condition,indentLevel +1);
                PrintExpressionTree(whilexp.Instructions,indentLevel +1);
            }
            
            
            else if(node is SelectorExpression selector)
            {
                PrintExpressionTree(selector.Source,indentLevel+1);
                PrintExpressionTree(selector.Single,indentLevel+1);
                PrintExpressionTree(selector.Predicate,indentLevel+1);
            }
            
            
            else if(node is PredicateExp predicate)
            {
                PrintExpressionTree(predicate.Unit,indentLevel+1);
                PrintExpressionTree(predicate.Condition,indentLevel+1);
            }
            
            
            else
                throw new Exception("UnHandled Expression");

        }
    }
}
public class CheckingContext: IContext
{
    public bool Turn{get;}
    public CustomList<ICard> Find(Expression exp)
    {
        CustomList<ICard> result= new(null,null);
        if(exp is PredicateExp predicate)
        {
            foreach(ICard card in Board.list)
            {
                predicate.Unit.Value= card;
                if((bool)predicate.Condition.Evaluate(exp.Evaluator, null))
                {
                    result.Add(card);
                }
            }
        }
        return result;
    }
    
    public CustomList<ICard> Deck{get; set;}= new CustomList<ICard>(true,true)
    {
    };
    public CustomList<ICard> OtherDeck{get; set;}= new CustomList<ICard>(true,true)
    {
    };

    public CustomList<ICard> DeckOfPlayer(IPlayer player)
    {
        if(player.Turn)
        {
            return Deck;
        }
        else
        {
        //Here OtherDeck
            return Deck;
        }
    }
    
    
    public CustomList<ICard> GraveYard{get; set;}= new CustomList<ICard>(true,true)
    {
    };

    public CustomList<ICard> OtherGraveYard{get; set;}= new CustomList<ICard>(true,true)
    {
    };

    public CustomList<ICard> GraveYardOfPlayer(IPlayer player)
    {
        if(player.Turn)
        {
            return GraveYard;
        }
        else
        {
            return OtherGraveYard;
        }
    }
    
    public CustomList<ICard> Field{get; set;}= new CustomList<ICard>(true,false)
    {
    };

    public CustomList<ICard> OtherField{get; set;}= new CustomList<ICard>(true,false)
    {
    };

    public CustomList<ICard> FieldOfPlayer(IPlayer player)
    {
        if(player.Turn)
        {
            return Field;
        }
        else
        {
            return OtherField;
        }
    }
    
    
    public CustomList<ICard> Hand{get; set;}= new CustomList<ICard>(true,true)
    {
    };

    public CustomList<ICard> OtherHand{get; set;}= new CustomList<ICard>(true,true)
    {
    };



    public CustomList<ICard> HandOfPlayer(IPlayer player)
    {
        if(player.Turn)
        {
            return Hand;
        }
        else
        {
            return OtherHand;
        }
    }
    public CustomList<ICard> Board{get; set;}= new CustomList<ICard>(true,false)
    {
    };

    public IPlayer TriggerPlayer{get; set;}
}