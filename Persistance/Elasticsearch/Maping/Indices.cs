using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Elasticsearch.Maping
{
    public static class Indices
    {
        public const string IndexAnalyzerName = "autocomplete";
        public const string SearchAnalyzerName = "autocomplete_search";


        public static IAnalysis AddSearchAnalyzer(this AnalysisDescriptor analysis)
        {
            const string lowercase = nameof(lowercase);

            return
                analysis
                    .Analyzers(a => a
                        .Custom(IndexAnalyzerName, c => c
                            .Tokenizer(IndexAnalyzerName)
                            .Filters(lowercase)
                        )
                        .Custom(SearchAnalyzerName, c =>
                            c.Tokenizer(lowercase)
                        )
                    )
                    .Tokenizers(t => t
                        .EdgeNGram(IndexAnalyzerName, e => e
                            .MinGram(1)
                            .MaxGram(20)
                            .TokenChars(TokenChar.Letter)
                        )
                    );
        }
    }
}
