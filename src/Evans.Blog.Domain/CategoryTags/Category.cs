using System;
using Evans.Blog.Consts;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Evans.Blog.CategoryTags
{
    public class Category : FullAuditedEntity<Guid>
    {
        public string CategoryName { get; set; }
        public string DisplayName  { get; set; }

        private Category()
        {
            /*
             * This constructor is for deserialization / ORM purpose
             */
        }

        internal Category(Guid id,[NotNull]string name,string displayName) : base(id)
        {
            SetName(name);
            DisplayName = displayName;
        }

        internal Category ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            CategoryName = Check.NotNullOrWhiteSpace(
                name, 
                nameof(name), 
                maxLength: ConstraintConsts.MaxNameLength
                );
        }
    }
}
