using System.Collections.Generic;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details for updating or creating content groups
    /// </summary>
    internal class CreateUpdateContent
    {
        private IEnumerable<CreateUpdateContentTemplate> m_templates;

        /// <summary />
        public CreateUpdateContent()
        {
            m_templates = new List<CreateUpdateContentTemplate>();
        }

        /// <summary>
        /// The name of the content
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Addtional description data
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List of templates to create or update along with the content item.
        /// </summary>
        public IEnumerable<CreateUpdateContentTemplate> Templates
        {
            get { return m_templates; }
            set { m_templates = value ?? new List<CreateUpdateContentTemplate>(); }
        }
    }
}
