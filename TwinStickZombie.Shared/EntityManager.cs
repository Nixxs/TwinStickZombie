using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace TwinStickZombie.Shared
{
    static class EntityManager
    {
        static List<Entity> entities = new List<Entity>();
        static List<Entity> addedEntities = new List<Entity>();

        // to track if we are currently looping through all the entities and running thier update
        // methods on them right now or not. We don't want ot touch the list if it's currently doing this
        static bool isUpdating;
        
        public static int Count
        {
            get
            {
                return entities.Count;
            }
        }

        // a method for adding in new entities into the entity manager
        public static void Add(Entity entity)
        {
            // check if it is updating first before adding a new entity to the list
            // you don't want to be adding things to a list that is currently being worked
            // on already
            if (isUpdating == false)
            {
                entities.Add(entity);
            }
            // if it is currently updating then just add the new entity to the added entities list
            else
            {
                addedEntities.Add(entity);
            }
        }

        // a method to run all the update methods for all the entities being managed
        public static void Update()
        {
            isUpdating = true;

            // run the update method in all the currently managed entities
            foreach (var entity in entities)
            {
                entity.Update();
            }

            // run through the added entities list and add them all to the entities list
            foreach (var entity in addedEntities)
            {
                entities.Add(entity);
            }

            // now that all the added entities have been added to the entities list we can clear this list out
            addedEntities.Clear();
            // using linq to filter the entities list to only the ones that are not expired
            entities = entities.Where(entity => entity.IsExpired == false).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in entities)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}
