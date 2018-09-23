using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using Assets.Model;
using Assets.Model.Areas;

namespace Assets.Model
{
    public static class ClsSaveLoad
    {
        private static string _filePath = (Application.persistentDataPath + "/Saves/savefile.txt");


        //SAVE----
        public static void Save(GameModel prGameModel)
        {
            using (FileStream lcFileStream = new FileStream(_filePath, FileMode.Create))
            {
                BinaryFormatter lcFormatter = new BinaryFormatter();
                lcFormatter.Serialize(lcFileStream, prGameModel);
            }
        }
        //---------


        //LOAD---
        public static void Load(GameModel prGameModel)
        {
            using (FileStream lcFileStream = new FileStream(_filePath, FileMode.Open))
            {
                BinaryFormatter lcFormatter = new BinaryFormatter();
                prGameModel = (GameModel)lcFormatter.Deserialize(lcFileStream);
            }
        }
        //-------





        private static object DuplicateObject(object prObject)
        {
            //Serialize the passed tour
            MemoryStream lcMemoryStream = SerializeToStream(prObject);

            //Deserialize the tour into the tour copy
            object _objectCopy = (object)DeserializeFromStream(lcMemoryStream);

            return _objectCopy; //Return the copy
        }

        private static object DeserializeFromStream(MemoryStream prMemoryStream)
        {

            BinaryFormatter lcFormatter = new BinaryFormatter();
            prMemoryStream.Seek(0, SeekOrigin.Begin);
            object lcObjectCopy = (object)lcFormatter.Deserialize(prMemoryStream);
            return lcObjectCopy;
        }

        private static MemoryStream SerializeToStream(object prObject)
        {
            MemoryStream lcStream = new MemoryStream();
            BinaryFormatter lcFormatter = new BinaryFormatter();
            lcFormatter.Serialize(lcStream, prObject);
            return lcStream;
        }
    }
}
