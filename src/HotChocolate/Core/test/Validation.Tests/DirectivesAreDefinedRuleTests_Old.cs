﻿using HotChocolate.Language;
using Xunit;

namespace HotChocolate.Validation
{
    public class DirectivesAreDefinedRuleTests_Old
        : ValidationTestBase
    {
        public DirectivesAreDefinedRuleTests_Old()
            : base(new DirectivesAreDefinedRule())
        {
        }

        [Fact]
        public void SupportedDirective()
        {
            // arrange
            Schema schema = ValidationUtils.CreateSchema();
            DocumentNode query = Utf8GraphQLParser.Parse(@"
                {
                    dog {
                        name @skip(if: true)
                    }
                }
            ");

            // act
            QueryValidationResult result = Rule.Validate(schema, query);

            // assert
            Assert.False(result.HasErrors);
        }

        [Fact]
        public void UnsupportedDirective()
        {
            // arrange
            Schema schema = ValidationUtils.CreateSchema();
            DocumentNode query = Utf8GraphQLParser.Parse(@"
                {
                    dog {
                        name @foo(bar: true)
                    }
                }
            ");

            // act
            QueryValidationResult result = Rule.Validate(schema, query);

            // assert
            Assert.True(result.HasErrors);
            Assert.Collection(result.Errors,
                t => Assert.Equal(
                    "The specified directive `foo` " +
                    "is not supported by the current schema.",
                    t.Message));
        }
    }
}
