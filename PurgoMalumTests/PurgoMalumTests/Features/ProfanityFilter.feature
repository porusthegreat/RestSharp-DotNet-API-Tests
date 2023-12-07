@ProfanityFilter
Feature: Profanity Filter Tests

    Scenario: Should return filtered text
        When I make a 'json' request with text as 'bad@$$'
        Then the response should be 'json' as 'bad***'

    Scenario: Should return filtered text with replacement 
        When I make a 'json' request with the text as 'bad@$$' and the replacement as 'ass'
        Then the response should be 'json' as 'bad ass'

    Scenario Outline: Should return filtered text with replacement as None
        When I make a '<contentType>' request with the text as '<input>' and the replacement as '<fillText>'
        Then the request should respond with '<contentType>' error as '<Error>'

        Examples:
          | input  | fillText               | Error                                                 | contentType |
          | bad@$s | qwertyuiopasdfghjklzxc | User Replacement Text Exceeds Limit of 20 Characters. | json        |
          | fucker | @$%sghffhgj            | Invalid User Replacement Text                         | xml         |

    Scenario: should filter given text with said characters for additional words along with profanity
        When I make a "xml" request with text as "some random bastard" and add "random, words" by replacing chars as "~"
        Then the response should be 'xml' as 'some ~~~~~~ ~~~~~~~'