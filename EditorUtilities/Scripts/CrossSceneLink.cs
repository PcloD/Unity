using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CrossSceneLink : MonoBehaviour
{
	public string componentName;
	public string attributeName;
	public string gameObjectPath;

	string _componentName;
	string _attributeName;
	string _gameObjectPath;

	void Update()
	{
		if(componentName != _componentName || attributeName != _attributeName || gameObjectPath != _gameObjectPath)
		{
			Component component;
			System.Reflection.FieldInfo info;
			GameObject linkedGameObject;

			_componentName = componentName;
			_attributeName = attributeName;
			_gameObjectPath = gameObjectPath;

			component = gameObject.GetComponent(componentName);

			if(component == null)
			{
				return;
			}

			info = component.GetType().GetField(attributeName);

			if(info == null)
			{
				return;
			}

			linkedGameObject = GameObject.Find(gameObjectPath);
			info.SetValue(component, linkedGameObject);
		}
	}
}
