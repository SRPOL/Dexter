﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DexterCRC.Src.CheckerLogic;
using DexterCS;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DexterCRC.Src.Crc
{
    public class CommentCRC : ICRCLogic
    {
        CommentRules commentRules;

        public CommentCRC()
        {
           commentRules = new CommentRules();
        }


        public void Analyze(AnalysisConfig config, AnalysisResult result, Checker checker, SyntaxNode syntaxRoot)
        {
            var commentRaws = syntaxRoot.DescendantNodes().OfType<XmlCommentSyntax>();
            if (!commentRaws.Any())
            {
                return;
            }


            foreach (var commentRaw in commentRaws)
            {
                if (commentRules.HasDefect(commentRaws))
                {
                    PreOccurence preOcc = commentRules.MakeDefect(config, checker, commentRaw);
                    result.AddDefectWithPreOccurence(preOcc);
                }       
            }
            throw new NotImplementedException();
        }
    }
}