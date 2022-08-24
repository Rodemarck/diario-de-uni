using UnityEngine;

namespace Entitys{
    [DisallowMultipleComponent]
    public abstract class Entity : MonoBehaviour {
        public string FirstName;
        public string LastName;
        public MedicalInformation medicalInfo;
        public SocialInformation socialInfo;
    }
}