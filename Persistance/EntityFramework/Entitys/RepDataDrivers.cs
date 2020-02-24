using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Persistance.EntityFramework.Entitys
{
    [Table("REP_DATA_DRIVES")]
    public class RepDataDrivers
    {
        [Key]
        [Column("USER_ID")]
        public long UserId { get; set; }
                
        [Column("DEVICE_ID")]
        public long DeviceId { get; set; }

        [Column("DEVICE_USER_ID")]
        public long? DeviceUserId { get; set; }

        [Column("DRIVE_START_TRACKLOG_ID")]
        public long? DriveStartTracklogId { get; set; }

        [Column("DRIVE_STOP_TRACKLOG_ID")]
        public long? DriveStopTrackLogId { get; set; }

        [Column("DRIVE_START_LT_DT")]
        public DateTime DriveStartLtDt { get; set; }

        [Column("DRIVE_STOP_LT_DT")]
        public DateTime DriveStopLtDt { get; set; }

        [MaxLength(100)]
        [Column("DRIVE_START_ADDRESS")]
        public string DriveStartAddress { get; set; }

        [MaxLength(100)]
        [Column("DRIVE_STOP_ADDRESS")]
        public string DriveStopAddress { get; set; }

        [Column("DRIVE_START_WM_X")]
        public int? DriveStartWmX { get; set; }

        [Column("DRIVE_START_WM_Y")]
        public int? DriveStartWmY { get; set; }

        [Column("DRIVE_STOP_WM_X")]
        public int? DriveStopWmX { get; set; }

        [Column("DRIVE_STOP_WM_Y")]
        public int? DriveStopWmY { get; set; }

        [Column("DRIVE_START_LAT")]
        public int? DriveStartLat { get; set; }

        [Column("DRIVE_START_LON")]
        public int? DriveStartLon { get; set; }

        [Column("DRIVE_STOP_LAT")]
        public int? DriveStopLat { get; set; }

        [Column("DRIVE_STOP_LON")]
        public int? DriveStopLon { get; set; }

        [Column("DRIVE_START_X")]
        public int? DriveStartX { get; set; }

        [Column("DRIVE_START_Y")]
        public int? DriveStartY { get; set; }

        [Column("DRIVE_STOP_X")]
        public int? DriveStopX { get; set; }

        [Column("DRIVE_STOP_Y")]
        public int? DriveStopY { get; set; }

        [Column("DRIVE_DURATION")]
        public int? DriveFuration { get; set; }

        [MaxLength(20)]
        [Column("VEHICLE_REGISTRATION")]
        public string VehicleRegistration { get; set; }

        [MaxLength(50)]
        [Column("DEVICE_ALIAS")]
        public string DeviceAlisa { get; set; }

        [MaxLength(100)]
        [Column("DEVICE_USER_FIRSTNAME")]
        public string DeviceUserFirstName { get; set; }

        [MaxLength(100)]
        [Column("DEVICE_USER_LASTNAME")]
        public string DeviceUserLastName { get; set; }

        [Column("DRIVE_DISTANCE")]
        public long? DriveDistance { get; set; }

        [Column("STOP_DURATION")]
        public long? StopDuration { get; set; }

        [Column("MILEAGE_START")]
        public long? MileageStart { get; set; }

        [Column("MILEAGE_END")]
        public long? MileageEnd { get; set; }

        [MaxLength(150)]
        [Column("VEHICLE_OTHER_INFO")]
        public string VehicleOtherInfo { get; set; }
    }
}
