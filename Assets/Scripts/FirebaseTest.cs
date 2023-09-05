using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Unity.VisualScripting;

public class FirebaseTest : MonoBehaviour {
    private DatabaseReference _reference;
    private string[] _userIDArray;

	private void Awake() {
        _reference = FirebaseDatabase.DefaultInstance.RootReference;
	}

	private void Start() {
        _userIDArray = new string[4] {
            "1111-0000",
			"2222-0000",
            "3333-0000",
            "4444-0000"
		};

        WriteUserData(_userIDArray[0], "riesling");
        WriteUserData(_userIDArray[1], "dawnn");
		WriteUserData(_userIDArray[2], "anigo123");
		WriteUserData(_userIDArray[3], "defaultUser");

        // ReadUserData();
    }

    public void ReadUserData() {
        var userRef = _reference.Child("users");
        userRef.GetValueAsync().ContinueWithOnMainThread(task => {
                if (task.IsFaulted) {
                    Debug.LogError("Task Failed..");
                }
                else {
                    DataSnapshot snapshot = task.Result;
                    for (int i = 0; i < snapshot.ChildrenCount; i++) {
                        string currUID = _userIDArray[i];
                        string name = snapshot.Child(currUID).Child("userName").Value.ToString();
                        Debug.Log(name);
                    }
                }    
            }
        );
    }

    public void WriteUserData(string uid, string userName) {
        var userNameRef = _reference.Child("users").Child(uid).Child("userName");
		userNameRef.SetValueAsync(userName);
	}
}
