using System;
using System.Collections.Generic;

namespace App.Domain.Entities
{
    public class Roles
    {
        public readonly int Value;

        public static readonly Roles Owner = new Roles(1);
        public static readonly Roles Admin = new Roles(2);
        public static readonly Roles User = new Roles(3);

        public Roles(int v)
        {
            Value = v;
        }

        public override string ToString()
        {
            return GetString(Value);
        }

        public static Dictionary<int, string> GetItemList()
        {
            var list = new Dictionary<int, string> { { 1, "Owner" }, { 2, "Admin" }, { 3, "User" } };
            return list;
        }

        public static bool IsValid(int id)
        {
            return id > 0 && id <= GetItemList().Count;
        }

        public static string GetString(int id)
        {
            var list = GetItemList();

            if (!list.ContainsKey(id))
            {
                throw new Exception("Unknown RoleId > " + id);
            }

            return list[id];
        }
    }
}
