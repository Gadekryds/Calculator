# Calculator

The calculator accepts 
* integers
* doubles
* +
* -
* \*
* /

and will calculate these together.

## Translating Infix to Postfix 

Using **Shunting-Yard Algorithm** we're able to translate the normal mathematical notation
` operand operator operand `
` op1 + op2 `

To the Postfix notation (RPN - Reverse Polish Notation)
` op1 op2 + `

This allows us, to evaluate more complex calculations with sequential mathematical operations.
` op1 + op2 * op3 / op4 `
