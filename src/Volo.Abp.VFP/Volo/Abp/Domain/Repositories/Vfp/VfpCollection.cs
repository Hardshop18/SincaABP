using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public class VfpCollection<TEntity> : IVfpCollection<TEntity>
        where TEntity : class, IEntity
    {
        private readonly Dictionary<string, byte[]> _dictionary = new Dictionary<string, byte[]>();

        private readonly IVfpSerializer _vfpSerializer;

        public VfpCollection(IVfpSerializer vfpSerializer)
        {
            _vfpSerializer = vfpSerializer;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            foreach (var entity in _dictionary.Values)
            {
                yield return _vfpSerializer.Deserialize(entity, typeof(TEntity)).As<TEntity>();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TEntity entity)
        {
            _dictionary.Add(GetEntityKey(entity), _vfpSerializer.Serialize(entity));
        }

        public void Update(TEntity entity)
        {
            if (_dictionary.ContainsKey(GetEntityKey(entity)))
            {
                _dictionary[GetEntityKey(entity)] = _vfpSerializer.Serialize(entity);
            }
        }

        public void Remove(TEntity entity)
        {
            _dictionary.Remove(GetEntityKey(entity));
        }

        private string GetEntityKey(TEntity entity)
        {
            return entity.GetKeys().JoinAsString(",");
        }
    }
}