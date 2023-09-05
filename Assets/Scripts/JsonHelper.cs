using System.Text;
using System.IO;
using UnityEngine;

public static class JsonHelper {
	[System.Serializable]
	private class Wrapper<T> {
		public T[] items;
	}

	public static T[] LoadJsonFile<T>(string path) {
		FileStream fileStream = new FileStream(path, FileMode.Open);
		byte[] data = new byte[fileStream.Length];
		fileStream.Read(data, 0, data.Length);
		fileStream.Close();

		string jsonData = Encoding.UTF8.GetString(data);
		return FromJson<T>(jsonData);
	}

	public static T[] FromJson<T>(string jsonData) {
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jsonData);
		return wrapper.items;
	}
}
