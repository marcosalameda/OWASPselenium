
using NUnit.Framework;

using CSGenio.business;
using CSGenio.persistence;
using CSGenio.framework;

// USE /[MANUAL GQT IMPORTS]/
//Platform: CS | Type: IMPORTS | Module: GQT | Parameter: ReorderFloatField | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:0307bf9b-becb-4886-9e92-9b17798eeaa1
using Quidgest.Persistence.GenericQuery;
//END_MANUALCODE

namespace WebTest
{
//Platform: CS | Type: SERVER_UNIT_TEST | Module: GQT | Parameter: ReorderFloatField | File:  | Order: 0
//BEGIN_MANUALCODE_CODMANUA:842a53e5-f088-4791-8de3-417b3a7facae
    /// <summary>
    /// Unit tests for the implicit re‑ordering mechanism behind the <see cref="CSGenioAroigf.ValOrder"/> field.
    /// Tests are executed in parallel; therefore each test creates its own parent record (<see cref="CSGenioArogl1"/>) to
    /// avoid unique-index violations on <c><see cref="CSGenioArogl1.ValCodrogl1"/></c>.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public sealed class ReorderFloatFieldTests : DatabaseTransactionFixture
    {
        private const int BaselineRecords = 10;

        #region Test helpers

        /// <summary>
        /// Creates and persists a parent “group” record so that child rows share the
        /// same foreign key but remain isolated from other tests.
        /// A locally unique <c>ValTitle</c> is generated to minimise the likelihood of
        /// conflicting with data seeded elsewhere.
        /// </summary>
        private string CreateTestDataGroup()
        {
            var group = new CSGenioArogl1(_user)
            {
                UserRecord = false,
                ValTitle = $"Test group {Guid.NewGuid():N}",
                ValZzstate = 0
            };
            group.insert(sp);

            return group.QPrimaryKey;
        }

        /// <summary>
        /// Creates <paramref name="maxRecords"/> baseline child rows using sequential <c>ValOrder</c> values.
        /// The primary keys are returned in a dictionary keyed by the initial order value for convenience.
        /// </summary>
        private Dictionary<decimal, string> CreateTestData(int maxRecords, string groupKey)
        {
            var keys = new Dictionary<decimal, string>(capacity: maxRecords);

            for (int order = 1; order <= maxRecords; order++)
            {
                var record = new CSGenioAroigf(_user)
                {
                    UserRecord = false,
                    ValCodrogl1 = groupKey,
                    ValOrder = order,
                    ValTitle = $"Baseline test record {order}",
                    ValZzstate = 0
                };
                record.insert(sp);
                keys.Add(order, record.QPrimaryKey);
            }

            return keys;
        }

        /// <summary>
        /// Ensures the list is contiguous, ordered, and unique.
        /// </summary>
        private static void AssertContiguous(IReadOnlyList<CSGenioAroigf> records)
        {
            var orders = records.Select(r => r.ValOrder).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(orders, Is.Ordered, "Sequence is not ordered.");
                Assert.That(orders, Is.Unique, "Duplicate ValOrder values detected.");
                Assert.That(orders.First(), Is.EqualTo(1m), "Sequence should start at 1.");
                Assert.That(orders.Last(), Is.EqualTo((decimal)orders.Count),
                            "Sequence should end at Count with no gaps.");
            });
        }

        /// <summary>
        /// Materialises all rows for the supplied <paramref name="groupKey"/> ordered by <c><see cref="CSGenioAroigf.ValOrder"/></c>.
        private List<CSGenioAroigf> FetchOrderedRows(string groupKey) =>
            [.. CSGenioAroigf
                .searchList(sp, _user,
                    CriteriaSet.And()
                        .Equal(CSGenioAroigf.FldCodrogl1, groupKey))
                .OrderBy(r => r.ValOrder)];
        #endregion

        #region Insertion

        [TestCase(1.0, true, Description = "Insert at the very beginning of the sequence.")]
        //[TestCase(1.5, true, Description = "Insert at the very beginning of the sequence.")]// Not yet supported
        [TestCase(5.0, true, Description = "Insert in the middle of the sequence.")]
        [TestCase(5.5, true, Description = "Insert in the middle of the sequence.")]
        [TestCase(10.0, true, Description = "Insert just before the final baseline record.")]
        [TestCase(10.5, true, Description = "Insert just before the final baseline record.")]
        public void Insert_WhenGivenAnIntermediateOrder_ShiftsSubsequentRecords(decimal orderToInsert, bool userRecord)
        {
            // Arrange
            var groupKey = CreateTestDataGroup();
            CreateTestData(BaselineRecords, groupKey);
            var newRecord = new CSGenioAroigf(_user)
            {
                UserRecord = userRecord,
                ValCodrogl1 = groupKey,
                ValTitle = $"Inserted at position {orderToInsert}",
                ValZzstate = 0
            };

            // Act
            if (!userRecord) // System-initiated action, assign order directly
                newRecord.ValOrder = orderToInsert;

            newRecord.insert(sp);

            if (userRecord) // UI-initiated action: first insert with negative order, then update to correct position
            {
                newRecord.ValOrder = orderToInsert;
                newRecord.update(sp);
            }

            // Assert
            var ordered = FetchOrderedRows(groupKey); // The zero-based starting index

            // The collection should now contain one extra record and remain contiguous.
            Assert.That(ordered, Has.Count.EqualTo(BaselineRecords + 1));
            AssertContiguous(ordered);

            // The newly inserted record occupies the correct position.
            Assert.That(ordered[(int)orderToInsert - 1].ValCodroigf,
                Is.EqualTo(newRecord.QPrimaryKey),
                "Inserted record did not occupy the expected position.");
        }

        [TestCase(true, Description = "Insert after the final record should append without shifting.")]
        public void Insert_WhenGivenOrderGreaterThanCount_AppendsToTheEnd(bool userRecord)
        {
            // Arrange
            var groupKey = CreateTestDataGroup();
            CreateTestData(BaselineRecords, groupKey);
            decimal newOrder = BaselineRecords + 1m; // +5 // intentionally oversized // Intentionally beyond range

            var newRecord = new CSGenioAroigf(_user)
            {
                UserRecord = userRecord,
                ValCodrogl1 = groupKey,
                ValTitle = "Inserted beyond the end",
                ValZzstate = 0
            };

            // Act
            if (!userRecord) // System-initiated action, assign order directly
                newRecord.ValOrder = newOrder;

            newRecord.insert(sp);

            if(userRecord)  // UI-initiated action: first insert with negative order, then update to correct position
            {
                newRecord.ValOrder = newOrder;
                newRecord.update(sp);
            }

            // Assert
            var ordered = FetchOrderedRows(groupKey); // The zero-based starting index

            Assert.That(ordered, Has.Count.EqualTo(BaselineRecords + 1));
            AssertContiguous(ordered);
            Assert.That(ordered.Last().ValCodroigf,
                Is.EqualTo(newRecord.QPrimaryKey),
                "Record was not appended to the end as expected.");
        }

        #endregion


        #region Updates

        [Test(Description = "Updating a record to a smaller order should move it up and shift others down.")]
        public void Update_WhenMovingRecordUp_ShiftsDownIntermediateRecords()
        {
            // Arrange
            var groupKey = CreateTestDataGroup();
            var keys = CreateTestData(BaselineRecords, groupKey);
            var target = CSGenioAroigf.search(sp, keys[8], _user); // Originally at position 8
            target.ValOrder = 3m;

            // Act
            target.update(sp);

            // Assert
            var ordered = FetchOrderedRows(groupKey); // The zero-based starting index

            AssertContiguous(ordered);

            Assert.That(ordered[2].ValCodroigf, Is.EqualTo(target.QPrimaryKey), "Record at position 8 should move to position 3.");
            Assert.Multiple(() =>
            {
                Assert.That(ordered[3].ValCodroigf, Is.EqualTo(keys[3]), "Record at position 3 should shift to position 4.");
                Assert.That(ordered[7].ValCodroigf, Is.EqualTo(keys[7]), "Record at position 7 should shift to position 8.");
                Assert.That(ordered[8].ValCodroigf, Is.EqualTo(keys[9]), "Record at position 9 should remain unchanged.");
            });
        }

        [Test(Description = "Updating a record to a larger order should move it down and shift others up.")]
        public void Update_WhenMovingRecordDown_ShiftsUpIntermediateRecords()
        {
            // Arrange
            var groupKey = CreateTestDataGroup();
            var keys = CreateTestData(BaselineRecords, groupKey);
            var target = CSGenioAroigf.search(sp, keys[2], _user); // Originally at position 2
            target.ValOrder = 9m;

            // Act
            target.update(sp);

            // Assert
            var ordered = FetchOrderedRows(groupKey); // The zero-based starting index

            AssertContiguous(ordered);

            Assert.That(ordered[8].ValCodroigf, Is.EqualTo(target.QPrimaryKey), "Record at position 2 should move to position 9.");
            Assert.Multiple(() =>
            {
                Assert.That(ordered[1].ValCodroigf, Is.EqualTo(keys[3]), "Record at position 3 should shift up to position 2.");
                Assert.That(ordered[7].ValCodroigf, Is.EqualTo(keys[9]), "Record at position 9 should shift up to position 8.");
                Assert.That(ordered[9].ValCodroigf, Is.EqualTo(keys[10]), "Record at position 10 should remain unchanged.");
            });
        }
        #endregion


        #region Deletion

        [Test(Description = "Deleting a record should close the gap in the sequence.")]
        public void Delete_WhenRemovingRecord_ShiftsSubsequentRecordsUp()
        {
            // Arrange
            var groupKey = CreateTestDataGroup();
            var keys = CreateTestData(BaselineRecords, groupKey);
            var target = CSGenioAroigf.search(sp, keys[4], _user); // Originally at position 4

            // Act
            target.delete(sp);

            // Assert
            var ordered = FetchOrderedRows(groupKey); // The zero-based starting index

            Assert.That(ordered, Has.Count.EqualTo(BaselineRecords - 1));
            AssertContiguous(ordered);
            Assert.Multiple(() =>
            {
                Assert.That(ordered[3].ValCodroigf, Is.EqualTo(keys[5]), "Record at position 5 should move up to fill position 4.");
                Assert.That(ordered[3].ValOrder, Is.EqualTo(4m), "Sequence gap was not properly closed.");
            });
        }
        #endregion
    }
//END_MANUALCODE
}