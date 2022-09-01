using ObjectsOnScene;

namespace Characters
{
    public class DataVisit
    {
        private TypeService typeService;
        private TypeItem typeItem;

        public TypeService GetTypeService { get => typeService; }
        public TypeItem GetTypeItem { get => typeItem; }

        public DataVisit(TypeService typeService, TypeItem typeItem)
        {
            this.typeService = typeService;
            this.typeItem = typeItem;
        }
    }
}
