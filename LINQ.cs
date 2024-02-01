using System.Collections.Generic;
using System.Linq;

namespace Linq {
    internal class Program {
        public class Medicine {
            public int med_id { get; set; }
            public string name { get; set; }
            public int category_id { get; set; }
            public int pres_required { get; set; }

            public static List<Medicine> GetMed() {
                return new List<Medicine> {
                    new Medicine { med_id = 1, name = "Paracetamol", category_id = 1, pres_required = 0 },
                    new Medicine { med_id = 2, name = "Ibuprofen", category_id = 1, pres_required = 0 },
                    new Medicine { med_id = 3, name = "Amoxicillin", category_id = 3, pres_required = 1 },
                    new Medicine { med_id = 4, name = "Lisinopril", category_id = 3, pres_required = 1 },
                    new Medicine { med_id = 5, name = "Simvastatin", category_id = 3, pres_required = 1 },
                    new Medicine { med_id = 6, name = "Aspirin", category_id = 3, pres_required = 0 },
                    new Medicine { med_id = 7, name = "Omeprazole", category_id = 2, pres_required = 1 },
                    new Medicine { med_id = 8, name = "Metformin", category_id = 3, pres_required = 1 },
                    new Medicine { med_id = 9, name = "Diazepam", category_id = 6, pres_required = 1 },
                    new Medicine { med_id = 10, name = "Cetirizine", category_id = 5, pres_required = 0 }

                };
            }

            public class Med_Category {
                public int med_cat_id { get; set; }
                public string name { get; set; }

                public static List<Med_Category> GetMedCats() {
                    return new List<Med_Category> {
                            new Med_Category { med_cat_id = 1, name = "Heart" },
                            new Med_Category { med_cat_id = 2, name = "Heart" },
                            new Med_Category { med_cat_id = 3, name = "Surgical" },
                            new Med_Category { med_cat_id = 4, name = "Orthopedics" },
                            new Med_Category { med_cat_id = 5, name = "Pulmonology" },
                            new Med_Category { med_cat_id = 6, name = "Surgical" },
                            new Med_Category { med_cat_id = 7, name = "Surgical" },
                            new Med_Category { med_cat_id = 8, name = "Surgical" },
                            new Med_Category { med_cat_id = 9, name = "Heart" },
                            new Med_Category { med_cat_id = 10, name = "Pulmonology" }
                        };
                }
            }

            public class Store {
                public int store_id { get; set; }
                public string store_name { get; set; }
                public string branch { get; set; }
                public string city { get; set; }

                public static List<Store> GetStores() {
                    return new List<Store> {
                        new Store { store_id = 1, store_name = "DWATSON", branch = "6th Road", city = "RWP" },
                        new Store { store_id = 2, store_name = "LATEEF", branch = "F7", city = "ISB" },
                        new Store { store_id = 3, store_name = "SHAHEEN", branch = "Commerical", city = "RWP" },
                        new Store { store_id = 4, store_name = "DWATSON", branch = "G11", city = "ISB" },
                    };
                }
            }

            public class StoreHasMeds {
                public int med_id { get; set; }
                public int store_id { get; set; }
                public int quantity { get; set; }

                public static List<StoreHasMeds> GetStoreMeds() {
                    return new List<StoreHasMeds> {
                        new StoreHasMeds {med_id = 1, store_id = 1 ,quantity = 15},
                        new StoreHasMeds {med_id = 2, store_id = 1 ,quantity = 15},
                        new StoreHasMeds {med_id = 3, store_id = 1 ,quantity = 8},
                        new StoreHasMeds {med_id = 4, store_id = 1 ,quantity = 40},

                        new StoreHasMeds {med_id = 1, store_id = 2 ,quantity = 8},
                        new StoreHasMeds {med_id = 2, store_id = 2 ,quantity = 5},
                        new StoreHasMeds {med_id = 3, store_id = 2 ,quantity = 8},
                        new StoreHasMeds {med_id = 6, store_id = 2 ,quantity = 6},

                        new StoreHasMeds {med_id = 1, store_id = 3 ,quantity = 8},
                        new StoreHasMeds {med_id = 2, store_id = 3 ,quantity = 7},
                        new StoreHasMeds {med_id = 3, store_id = 3 ,quantity = 8},
                        new StoreHasMeds {med_id = 8, store_id = 3 ,quantity = 2},

                        new StoreHasMeds {med_id = 1, store_id = 4 ,quantity = 15},
                        new StoreHasMeds {med_id = 3, store_id = 4 ,quantity = 10},
                        new StoreHasMeds {med_id = 2, store_id = 4 ,quantity = 8},
                        new StoreHasMeds {med_id = 6, store_id = 4 ,quantity = 40},
                    };
                }
            }
            static void Main() {
                List<Medicine> meds = Medicine.GetMed();
                List<StoreHasMeds> storehasMeds = StoreHasMeds.GetStoreMeds();
                List<Store> stores = Store.GetStores();
                List<Med_Category> medCats = Med_Category.GetMedCats();

                var q1 = meds.Where(i => i.pres_required == 0)
                    .Join(storehasMeds, m => m.med_id, shm => shm.med_id, (m, shm) => new {
                        mid = m.med_id,
                        mname = m.name,
                        presreq = m.pres_required,
                        sid = shm.store_id
                    })
                    .Join(stores, shm => shm.sid, st => st.store_id, (shm, st) => new {
                        shm.mid,
                        shm.mname,
                        shm.presreq,
                        st.city,
                        stname = st.store_name
                    }).Where(i => i.city == "RWP");

                var q2 = meds.Join(medCats, m => m.category_id, mc => mc.med_cat_id, (m, mc) => new {
                    m_id = m.med_id,
                    m_name = m.name,
                    cat_name = mc.name
                }).Join(storehasMeds, mc => mc.m_id, shm => shm.med_id, (mc, shm) => new {
                    mc.m_id,
                    mc.m_name,
                    mc.cat_name,
                    st_id = shm.store_id,
                    qt = shm.quantity
                }).Join(stores, shm => shm.st_id, st => st.store_id, (shm, st) => new {
                    shm.m_id,
                    shm.m_name,
                    shm.cat_name,
                    shm.st_id,
                    shm.qt,
                    st.branch,
                    st.store_name

                }).Where(i => i.store_name == "DWATSON" && i.branch == "6th Road" && (i.cat_name == "Heart" || i.cat_name == "Surgical"))
                .GroupBy(i => i.cat_name).Select(cat => new {
                    category = cat.Key,
                    count = cat.Sum(s => s.qt)
                });

                var q3 = medCats.Join(meds, mc => mc.med_cat_id, m => m.category_id, (mc, m) => new {
                    mid = m.med_id,
                    cname = mc.name
                }).Join(storehasMeds, mc => mc.mid, shm => shm.med_id, (mc, shm) => new {
                    mc.mid,
                    mc.cname,
                    stid = shm.store_id,
                    qt = shm.quantity
                }).Where(i => i.qt < 10).Join(stores, mc => mc.stid, st => st.store_id, (mc, st) => new {
                    mc.cname,
                    st.city,
                }).Where(i => i.city == "ISB").Select(i => i.cname);

            }
        }
    }
}
