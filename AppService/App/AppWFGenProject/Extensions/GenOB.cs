using System;
using System.Collections.Generic;
using System.Text;

namespace AppWFGenProject.Extensions
{
    public class GenOB
    {
        public string rootDir { get; set; }
        public string nameproject { get; set; }
        public string common { get; set; }
        public string db { get; set; }
        public string Entity { get; set; }
        public string entity { get; set; }
        public string _entity { get; set; }
        public string version { get; set; }
        public string builderConfig { get; set; }
        public string builderFields { get; set; }
        public string paramCreate { get; set; }
        public string functionCreate { get; set; }
        public string builderProperties { get; set; }
        public string builderBehaviours { get; set; }
        public string builderRegister { get; set; }
        public string builderRequestParam { get; set; }
        public string builderSetUpdate { get; set; }
        public string builderPublic { get; set; }
        public string entityDTO { get; set; }
        public string builderConfigColum { get; set; }
        public Dictionary<string, string> getDictionatyChange() 
        {
            Dictionary<string, string> _dictionary = new Dictionary<string, string>();
            _dictionary.Add(EnumClass.nameproject, nameproject);
            _dictionary.Add(EnumClass.common, common);
            _dictionary.Add(EnumClass.db, db);
            _dictionary.Add(EnumClass.Entity, Entity);
            _dictionary.Add(EnumClass.entity, entity);
            _dictionary.Add(EnumClass._entity, _entity);
            _dictionary.Add(EnumClass.version, version);
            _dictionary.Add(EnumClass.builderConfig, builderConfig);
            _dictionary.Add(EnumClass.builderFields, builderFields);
            _dictionary.Add(EnumClass.paramCreate, paramCreate);
            _dictionary.Add(EnumClass.functionCreate, functionCreate);
            _dictionary.Add(EnumClass.builderProperties, builderProperties);
            _dictionary.Add(EnumClass.builderBehaviours, builderBehaviours);
            _dictionary.Add(EnumClass.builderRegister, builderRegister);
            _dictionary.Add(EnumClass.builderRequestParam, builderRequestParam);
            _dictionary.Add(EnumClass.builderSetUpdate, builderSetUpdate);
            _dictionary.Add(EnumClass.builderPublic, builderPublic);
            _dictionary.Add(EnumClass.entityDTO, entityDTO);
            _dictionary.Add(EnumClass.builderConfigColum, builderConfigColum);
            return _dictionary;
        }
    }
  
}
