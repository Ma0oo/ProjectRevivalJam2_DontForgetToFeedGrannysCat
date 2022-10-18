﻿using System;
using Plugins.MaoUtility.DataManagers;
using UnityEngine;

namespace DefaultNamespace.PropSystem
{
    [RequireComponent(typeof(PropParts))]
    public class Prop : MonoBehaviour
    {
        public IGeterDataManager<IPropPart> Props=>_parts??=GetComponent<PropParts>();
        [SerializeField] private PropParts _parts;
    }
}