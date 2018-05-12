using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest : MonoBehaviour {


	[Test]
	public void EditModeTest_DoesGridGeneratorInstantiateCorrectly() {
        var gameObject = Instantiate(Resources.Load<GameObject>("empty"), Vector3.zero, Quaternion.identity);
		gameObject.tag = "UnitTestPrefab";
		var gridGenerator = gameObject.AddComponent<GridGenerator>();

        Assert.AreEqual(gridGenerator.SlotPrefab, null);
		Assert.AreEqual(gridGenerator.HorizontalSlotCount, 0);
		Assert.AreEqual(gridGenerator.VerticalSlotCount, 0);
		Assert.AreEqual(gridGenerator.SlotSize, 0);
		Assert.AreEqual(gridGenerator.SlotSpacing, 0);
		Assert.AreEqual(gridGenerator.SlotHorizontalOffset, 0);
		Assert.AreEqual(gridGenerator.SlotVerticalOffset, 0);
    }

	[UnityTest]
	public IEnumerator _Test_Something() {
		// Do shit

		yield return new WaitForSeconds(2f);

		// Test or do more shit

		// Wait as many times as you want
		//yield return new WaitForSeconds(.6f);

		Assert.AreEqual(true, true);
	}

	[TearDown]
	public void TearDown() {
		var gameObjects = GameObject.FindGameObjectsWithTag("UnitTestPrefab");

		foreach(GameObject gameObject in gameObjects) {
			Destroy(gameObject);
		}
	}
}
