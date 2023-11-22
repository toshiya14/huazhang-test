using System.Text.Json;
using TestConsole;

var node3 = new Node { Value = 3 };
var node5 = new Node { Value = 5 };
var node9 = new Node { Value = 9, Left = node5, Right = node3 };
var node1 = new Node { Value = 1 };
var node6 = new Node { Value = 6 , Left = node1, Right = node9};
var node7 = new Node { Value = 7 };
var node4 = new Node { Value = 4 , Left = node6, Right = node7};

var visitor = new NodeVisitor(node4);
//var result = visitor.GetLeaves();
var isap = visitor.IsLeafAP();
Console.WriteLine(JsonSerializer.Serialize(isap));


