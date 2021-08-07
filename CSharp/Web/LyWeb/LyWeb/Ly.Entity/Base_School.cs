using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ly.Entity
{
    [Table("Base_School")]
    public class Base_School
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
