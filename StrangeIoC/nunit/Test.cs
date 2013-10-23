using System;
using NUnit.Framework;
using strange.examples.myfirstproject;

// Experimenting with the ideas exposed here: http://unity.bfowle.com/2013/09/getting-strange-unit-testing-unity/
// Each time you use 'Sync MonoDevelop Project' in Unity3D, you need to re-add the nunit.csproj to the solution ..

namespace nunit
{
		[TestFixture ()]
		public class Test
		{
				[Test ()]
				public void TestCase ()
				{
						// there's a MonoBehaviour there, so it's not possible outside of Unity itself
						//var foo 				= new MyFirstProjectRoot ();
						// this we can instanciate .. it's using strange, no dependencies on unity
						var foo = new ExampleService ();
				}
		}
}

